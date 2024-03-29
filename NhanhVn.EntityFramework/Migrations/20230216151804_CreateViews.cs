﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NhanhVn.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class CreateViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
 DROP VIEW public.revenue_overview_group;


CREATE OR REPLACE VIEW public.revenue_overview_group
 AS
 SELECT q.date,
    q.sale_channel,
    count(q.nhanh_id) AS ""order"",
	sum(q.item_quantity) as item_quantity,
    sum(q.pre_discount) AS pre_discount,
    sum(q.discount) AS discount,
    sum(q.gross_revenue) AS gross_revenue,
    sum(q.ship_fee) AS ship_fee,
    sum(q.customer_ship_fee) AS customer_ship_fee,
    sum(q.discount_ship) AS discount_ship,
    sum(q.net_revenue) AS net_revenue,
	q.cogs as cogs
   FROM (
	   SELECT o.nhanh_id,
            date(o.created_date_time) AS date,
                CASE o.sale_channel
                    WHEN 'Facebook'::text THEN 'Meta'::character varying
                    WHEN 'Instagram'::text THEN 'Meta'::character varying
                    ELSE o.sale_channel
                END AS sale_channel,
            sum(p.price * ((elem.value ->> 'Quantity'::text)::integer)::double precision) AS pre_discount,
            sum(p.price * ((elem.value ->> 'Quantity'::text)::integer)::double precision) - (o.calc_total_money - o.customer_ship_fee::double precision) AS discount,
            o.calc_total_money + o.money_transfer AS gross_revenue,
            o.ship_fee,
            o.customer_ship_fee,
	   	p.avg_cost as cogs,
		 sum(((elem.value ->> 'Quantity'::text)::integer)::double precision) AS item_quantity,
            o.ship_fee - o.customer_ship_fee AS discount_ship,
            o.calc_total_money - o.ship_fee::double precision AS net_revenue
           FROM orders o,
            LATERAL jsonb_array_elements(o.products) elem(value)
             JOIN products p ON p.id_nhanh = (elem.value ->> 'NhanhProductId'::text)
          GROUP BY o.ship_fee,	p.avg_cost, o.customer_ship_fee, o.nhanh_id, o.created_date_time, o.sale_channel, o.money_discount, o.calc_total_money, o.money_transfer) q
  GROUP BY q.date, q.sale_channel, q.cogs; 
");
            migrationBuilder.Sql(
                @"
                DROP VIEW IF EXISTS revenue_overview;

CREATE OR REPLACE VIEW public.revenue_overview
 AS
 SELECT o.nhanh_id,
    date(o.created_date_time) AS date,
    o.sale_channel,
    sum(p.price * ((elem.value ->> 'Quantity'::text)::integer)::double precision) AS pre_discount,
    sum(p.price * ((elem.value ->> 'Quantity'::text)::integer)::double precision) - (o.calc_total_money - o.customer_ship_fee::double precision) AS discount,
    o.calc_total_money + o.money_transfer AS gross_revenue,
    o.ship_fee,
    o.customer_ship_fee,
    o.ship_fee - o.customer_ship_fee AS discount_ship,
    o.calc_total_money - o.ship_fee::double precision AS net_revenue
   FROM orders o,
    LATERAL jsonb_array_elements(o.products) elem(value)
     JOIN products p ON p.id_nhanh = (elem.value ->> 'NhanhProductId'::text)
  GROUP BY o.ship_fee, o.customer_ship_fee, o.nhanh_id, o.created_date_time, o.sale_channel, o.money_discount, o.calc_total_money, o.money_transfer;
                "
                );
            migrationBuilder.Sql(
                @"
                DROP VIEW IF EXISTS order_overview;

                CREATE VIEW order_overview AS
                WITH data AS (
                    select date(o.created_date_time) as date,
                    status_code,
                    o.calc_total_money - o.ship_fee as net_revenue
                    from public.orders as o
                )
                    SELECT
                    date,
                COUNT(*) as ""total status"",
                COUNT(*) FILTER(WHERE status_code = 'Confirmed' OR 
                      status_code = 'New' OR 
                      status_code = 'CustomerConfirming' OR 
                      status_code = 'Confirmed' OR 
                      status_code = 'Packing' OR 
                      status_code = 'Packed' OR 
                      status_code = 'ChangeDepot' OR 
                      status_code = 'Pickup'  
                      ) AS ""pre-delivery"",
                COUNT(*) FILTER(WHERE	status_code = 'Shipping') AS ""in-delivery"",
                COUNT(*) FILTER(WHERE status_code = 'Confirmed' OR 
                      status_code = 'Canceled' OR 
                      status_code = 'Aborted' OR 
                      status_code = 'CarrierCanceled' OR 
                      status_code = 'SoldOut'  
                      ) AS ""cancel"",
                COUNT(*) FILTER(WHERE status_code = 'Returning' OR 
                      status_code = 'Returned'  
                      ) AS ""return"",
                      
                SUM(net_revenue) as ""total amount"",
                SUM(net_revenue) FILTER(WHERE status_code = 'Confirmed' OR 
                      status_code = 'New' OR 
                      status_code = 'CustomerConfirming' OR 
                      status_code = 'Confirmed' OR 
                      status_code = 'Packing' OR 
                      status_code = 'Packed' OR 
                      status_code = 'ChangeDepot' OR 
                      status_code = 'Pickup'  
                      ) AS ""pre-delivery amount"",
                SUM(net_revenue) FILTER(WHERE	status_code = 'Shipping') AS ""in-delivery amount"",
                SUM(net_revenue)  FILTER(WHERE status_code = 'Confirmed' OR 
                      status_code = 'Canceled' OR 
                      status_code = 'Aborted' OR 
                      status_code = 'CarrierCanceled' OR 
                      status_code = 'SoldOut'  
                      ) AS ""cancel amount"",
                SUM(net_revenue) FILTER(WHERE status_code = 'Returning' OR 
                      status_code = 'Returned'  OR status_code = 'ConfirmReturned'
                      ) AS ""return amount""
                FROM data
                GROUP BY date"
                );

            migrationBuilder.Sql(@"
            DROP VIEW IF EXISTS order_product_count_180;

                CREATE VIEW order_product_count_180 AS
                WITH data AS (
                    select o.status_code,
                        j->>'ProductCode' as sku,
                        (j->>'Quantity')::integer quantity,
                        c.name as category,
                        pp.code as parent_sku
                    from public.orders  o
                        join lateral jsonb_array_elements(products) j on TRUE
                        join public.products p on p.id_nhanh = j->>'NhanhProductId'
                        join public.categories c on p.category_id = c.id
                        left join public.products pp on pp.id_nhanh = p.parent_id 
                    WHERE o.created_date_time >= NOW() - INTERVAL '180 days'
                )
                    SELECT	sku,
                    parent_sku,
                    category,
                -- SUM(net_revenue) as ""total amount"",
                SUM(quantity) FILTER(WHERE status_code = 'Confirmed' OR 
                      status_code = 'New' OR 
                      status_code = 'CustomerConfirming' OR 
                      status_code = 'Confirmed' OR 
                      status_code = 'Packing' OR 
                      status_code = 'Packed' OR 
                      status_code = 'ChangeDepot' OR 
                      status_code = 'Pickup'  
                      ) AS ""pre-delivery"",
                SUM(quantity) FILTER(WHERE	status_code = 'Shipping') AS ""in-delivery"",
                SUM(quantity)  FILTER(WHERE  
                      status_code = 'Canceled' OR 
                      status_code = 'Aborted' OR 
                      status_code = 'CarrierCanceled' OR 
                      status_code = 'SoldOut'  
                      ) AS ""cancel"",
                SUM(quantity) FILTER(WHERE status_code = 'Returning' OR 
                      status_code = 'Returned' OR status_code = 'ConfirmReturned'
                      ) AS ""return""
                FROM data
                GROUP BY sku,parent_sku,category
            ");

            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS balance_7;

                CREATE VIEW balance_7 AS
                SELECT p.code as sku, pp.code as parent_sku, c.name, COALESCE(o.sum_quantity,0) as sold, 
                    (p.inventory->>'Available')::integer as available,
                    COALESCE(ROUND(o.sum_quantity::numeric(10,2) / 7, 2), 0) as avg_sold,
                    COALESCE((p.inventory->>'Available')::integer - ROUND(o.sum_quantity::numeric(10,2) / 7, 2) * 7, 0) as inventory_balance
                FROM public.products p
                    left join public.products pp on pp.id_nhanh = p.parent_id 
                    left join public.categories c on p.category_id = c.id
                    LEFT JOIN (SELECT SUM((j->>'Quantity')::integer) as sum_quantity, j->>'NhanhProductId' as nhanh_product_id
                      FROM orders o
                      JOIN LATERAL jsonb_array_elements(o.products) j ON TRUE
                      WHERE o.created_date_time >= NOW() - INTERVAL '7 days'
                            AND  o.status_code NOT IN ( 'Canceled' , 
                              'Aborted', 
                              'CarrierCanceled', 
                              'SoldOut' ,
                              'Returning' ,
                              'Returned',
                            'ConfirmReturned')
                    GROUP BY j->>'NhanhProductId'
                            ) o
                    ON o.nhanh_product_id = p.id_nhanh
            ");
            migrationBuilder.Sql(@"
DROP VIEW IF EXISTS balance_14;

CREATE VIEW balance_14 AS
SELECT p.code as sku, pp.code as parent_sku, c.name, COALESCE(o.sum_quantity,0) as sold, 
	(p.inventory->>'Available')::integer as available,
	COALESCE(ROUND(o.sum_quantity::numeric(10,2) / 14, 2), 0) as avg_sold,
	COALESCE((p.inventory->>'Available')::integer - ROUND(o.sum_quantity::numeric(10,2) / 14, 2) * 14, 0) as inventory_balance
FROM public.products p
	left join public.products pp on pp.id_nhanh = p.parent_id 
	left join public.categories c on p.category_id = c.id
	LEFT JOIN (SELECT SUM((j->>'Quantity')::integer) as sum_quantity, j->>'NhanhProductId' as nhanh_product_id
	  FROM orders o
	  JOIN LATERAL jsonb_array_elements(o.products) j ON TRUE
	  WHERE o.created_date_time >= NOW() - INTERVAL '14 days'
			AND  o.status_code NOT IN ( 'Canceled' , 
			  'Aborted', 
			  'CarrierCanceled', 
			  'SoldOut' ,
			  'Returning' ,
			  'Returned',
				'ConfirmReturned')
	GROUP BY j->>'NhanhProductId'
			) o
	ON o.nhanh_product_id = p.id_nhanh
");

            migrationBuilder.Sql(@"
DROP VIEW IF EXISTS balance_30;

CREATE VIEW balance_30 AS
SELECT p.code as sku, pp.code as parent_sku, c.name, COALESCE(o.sum_quantity,0) as sold, 
	(p.inventory->>'Available')::integer as available,
	COALESCE(ROUND(o.sum_quantity::numeric(10,2) / 30, 2), 0) as avg_sold,
	COALESCE((p.inventory->>'Available')::integer - ROUND(o.sum_quantity::numeric(10,2) / 30, 2) * 30, 0) as inventory_balance
FROM public.products p
	left join public.products pp on pp.id_nhanh = p.parent_id 
	left join public.categories c on p.category_id = c.id
	LEFT JOIN (SELECT SUM((j->>'Quantity')::integer) as sum_quantity, j->>'NhanhProductId' as nhanh_product_id
	  FROM orders o
	  JOIN LATERAL jsonb_array_elements(o.products) j ON TRUE
	  WHERE o.created_date_time >= NOW() - INTERVAL '30 days'
			AND  o.status_code NOT IN ( 'Canceled' , 
			  'Aborted', 
			  'CarrierCanceled', 
			  'SoldOut' ,
			  'Returning' ,
			  'Returned',
				'ConfirmReturned')
	GROUP BY j->>'NhanhProductId'
			) o
	ON o.nhanh_product_id = p.id_nhanh

");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS revenue_overview;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS order_overview");
            migrationBuilder.Sql("DROP VIEW IF EXISTS order_product_count_180;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS balance_7;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS balance_14;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS balance_30;");
        }
    }
}
