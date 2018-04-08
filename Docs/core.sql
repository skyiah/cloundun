/*
Navicat PGSQL Data Transfer

Source Server         : 144000.tv
Source Server Version : 90606
Source Host           : 144000.tv:5432
Source Database       : core
Source Schema         : public

Target Server Type    : PGSQL
Target Server Version : 90606
File Encoding         : 65001

Date: 2018-04-08 14:17:47
*/


-- ----------------------------
-- Sequence structure for cashes_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."cashes_id_seq";
CREATE SEQUENCE "public"."cashes_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 20
 CACHE 1;
SELECT setval('"public"."cashes_id_seq"', 20, true);

-- ----------------------------
-- Sequence structure for orders_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."orders_id_seq";
CREATE SEQUENCE "public"."orders_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 212
 CACHE 1;
SELECT setval('"public"."orders_id_seq"', 212, true);

-- ----------------------------
-- Sequence structure for repays_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."repays_id_seq";
CREATE SEQUENCE "public"."repays_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 3
 CACHE 1;

-- ----------------------------
-- Table structure for cashes
-- ----------------------------
DROP TABLE IF EXISTS "public"."cashes";
CREATE TABLE "public"."cashes" (
"id" int4 DEFAULT nextval('cashes_id_seq'::regclass) NOT NULL,
"orgid" varchar(4) COLLATE "default" NOT NULL,
"date" date,
"code" int2,
"descr" varchar(20) COLLATE "default",
"receive" money,
"pay" money,
"creator" varchar(10) COLLATE "default"
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Table structure for chats
-- ----------------------------
DROP TABLE IF EXISTS "public"."chats";
CREATE TABLE "public"."chats" (
"orgid" varchar(4) COLLATE "default" NOT NULL,
"custwx" varchar(28) COLLATE "default" NOT NULL,
"custname" varchar(254) COLLATE "default",
"msgs" jsonb,
"quested" timestamp(6)
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Table structure for items
-- ----------------------------
DROP TABLE IF EXISTS "public"."items";
CREATE TABLE "public"."items" (
"orgid" varchar(4) COLLATE "default" NOT NULL,
"name" varchar(10) COLLATE "default" NOT NULL,
"descr" varchar(50) COLLATE "default",
"icon" bytea,
"unit" varchar(4) COLLATE "default",
"price" money,
"comp" money,
"min" int2,
"step" int2,
"stock" int2,
"status" int2
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Table structure for orders
-- ----------------------------
DROP TABLE IF EXISTS "public"."orders";
CREATE TABLE "public"."orders" (
"id" int4 DEFAULT nextval('orders_id_seq'::regclass) NOT NULL,
"rev" int2 DEFAULT 0 NOT NULL,
"orgid" varchar(4) COLLATE "default" NOT NULL,
"orgname" varchar(10) COLLATE "default",
"custwx" varchar(28) COLLATE "default",
"custname" varchar(10) COLLATE "default",
"custtel" varchar(11) COLLATE "default",
"custaddr" varchar(20) COLLATE "default",
"items" jsonb,
"total" money,
"net" money,
"created" timestamp(6),
"comp" bool,
"cash" money DEFAULT 0,
"paid" timestamp(6),
"aborted" timestamp(6),
"ended" timestamp(6),
"status" int2
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Table structure for orgs
-- ----------------------------
DROP TABLE IF EXISTS "public"."orgs";
CREATE TABLE "public"."orgs" (
"id" varchar(4) COLLATE "default" NOT NULL,
"name" varchar(10) COLLATE "default",
"descr" varchar(50) COLLATE "default",
"addr" varchar(20) COLLATE "default",
"x" float8,
"y" float8,
"icon" bytea,
"mgrwx" varchar(28) COLLATE "default",
"mgrname" varchar(10) COLLATE "default",
"mgrtel" varchar(11) COLLATE "default",
"oprwx" varchar(28) COLLATE "default",
"oprname" varchar(10) COLLATE "default",
"oprtel" varchar(11) COLLATE "default",
"status" int2
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Table structure for repays
-- ----------------------------
DROP TABLE IF EXISTS "public"."repays";
CREATE TABLE "public"."repays" (
"id" int4 DEFAULT nextval('repays_id_seq'::regclass) NOT NULL,
"orgid" varchar(4) COLLATE "default" NOT NULL,
"fro" date NOT NULL,
"till" date NOT NULL,
"orders" int4,
"total" money,
"cash" money,
"payer" varchar(6) COLLATE "default",
"err" varchar(40) COLLATE "default",
"status" int2 DEFAULT 0
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS "public"."users";
CREATE TABLE "public"."users" (
"wx" varchar(28) COLLATE "default" NOT NULL,
"name" varchar(10) COLLATE "default",
"tel" varchar(11) COLLATE "default",
"addr" varchar(20) COLLATE "default",
"credential" varchar(32) COLLATE "default",
"score" int4,
"refwx" varchar(28) COLLATE "default",
"oprat" varchar(4) COLLATE "default",
"opr" int2 DEFAULT 0,
"adm" int2
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Alter Sequences Owned By 
-- ----------------------------
ALTER SEQUENCE "public"."cashes_id_seq" OWNED BY "cashes"."id";
ALTER SEQUENCE "public"."orders_id_seq" OWNED BY "orders"."id";
ALTER SEQUENCE "public"."repays_id_seq" OWNED BY "repays"."id";

-- ----------------------------
-- Indexes structure for table cashes
-- ----------------------------
CREATE INDEX "cashes_orgiddate_index" ON "public"."cashes" USING btree ("orgid", "date");

-- ----------------------------
-- Primary Key structure for table cashes
-- ----------------------------
ALTER TABLE "public"."cashes" ADD PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table items
-- ----------------------------
ALTER TABLE "public"."items" ADD PRIMARY KEY ("orgid", "name");

-- ----------------------------
-- Indexes structure for table orders
-- ----------------------------
CREATE INDEX "orders_statuscustwx" ON "public"."orders" USING btree ("status", "custwx");
CREATE INDEX "orders_statusorgid" ON "public"."orders" USING btree ("status", "orgid");

-- ----------------------------
-- Primary Key structure for table orders
-- ----------------------------
ALTER TABLE "public"."orders" ADD PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table orgs
-- ----------------------------
ALTER TABLE "public"."orgs" ADD PRIMARY KEY ("id");

-- ----------------------------
-- Indexes structure for table repays
-- ----------------------------
CREATE INDEX "replays_orgidstatus_index" ON "public"."repays" USING btree ("orgid", "status");

-- ----------------------------
-- Primary Key structure for table repays
-- ----------------------------
ALTER TABLE "public"."repays" ADD PRIMARY KEY ("id");

-- ----------------------------
-- Indexes structure for table users
-- ----------------------------
CREATE INDEX "users_oprat" ON "public"."users" USING btree ("oprat") WHERE oprat IS NOT NULL;
CREATE INDEX "users_tel" ON "public"."users" USING hash ("tel") WHERE tel IS NOT NULL;

-- ----------------------------
-- Primary Key structure for table users
-- ----------------------------
ALTER TABLE "public"."users" ADD PRIMARY KEY ("wx");
