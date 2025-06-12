-- MySQL dump 10.13  Distrib 5.7.33, for Win64 (x86_64)
--
-- Host: localhost    Database: db_a68892_nodopay
-- ------------------------------------------------------
-- Server version	5.7.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `faq`
--

DROP TABLE IF EXISTS `faq`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faq` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `question` varchar(500) NOT NULL,
  `answer` text NOT NULL,
  `category` varchar(100) NOT NULL,
  `is_published` tinyint(1) NOT NULL DEFAULT '1',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=112 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faq`
--

LOCK TABLES `faq` WRITE;
/*!40000 ALTER TABLE `faq` DISABLE KEYS */;
INSERT INTO `faq` VALUES (6,'How do I create a Purchase Order?','Go to the Purchase Orders page and click “Create PO”, then follow the steps.','Purchase Orders',0,'2025-06-04 06:56:38','2025-06-06 09:47:59'),(7,'What does PO status “Pending” mean?','The PO has been created but not yet funded by NodoPay.','Purchase Orders',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(8,'Can I cancel a Purchase Order?','You can cancel a PO only if it has not yet been funded.','Purchase Orders',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(9,'Why is the payment date empty?','Payment date appears after NodoPay processes and disburses the PO.','Purchase Orders',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(10,'What happens after I submit a PO?','It moves to “Pending” status until NodoPay funds it.','Purchase Orders',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(11,'How do I add a new vendor?','Click “Add Vendor”, fill in the required fields, and save.','Vendors',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(12,'What vendor information is required?','You’ll need the name, bank account number, and bank name.','Vendors',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(13,'Can I edit vendor details later?','Yes, vendors can be edited from the vendor list.','Vendors',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(14,'Why is my vendor not showing when creating a PO?','Ensure the vendor was saved correctly and is not duplicated.','Vendors',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(15,'What is shown in vendor history?','It includes PO transactions and repayment records for that vendor.','Vendors',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(16,'Where do I make repayment transfers?','To the virtual account listed at the top of the Repayments page.','Repayments',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(17,'What does “On Time” status mean?','It means partial repayment has been made before the due date.','Repayments',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(18,'Can I repay a PO in parts?','Yes, partial repayments are supported and reflected in real time.','Repayments',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(19,'How are due dates determined?','Due dates are set during PO creation and can’t be changed.','Repayments',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(20,'What happens if I miss a due date?','The PO status changes to “Overdue” and will show alerts.','Repayments',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(21,'What is YTD Total PO Spend?','It shows the total value of all POs since the beginning of the year.','Purchase Tracker',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(22,'Can I filter by month?','The table automatically shows monthly breakdowns from January.','Purchase Tracker',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(23,'How is Top Vendor determined?','The vendor with the highest PO value in the selected month.','Purchase Tracker',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(24,'Does this page include charts?','No, the tracker provides simplified tabular data only.','Purchase Tracker',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(25,'Why is a month missing?','Only months with POs will appear in the tracker.','Purchase Tracker',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(101,'How often is the Dashboard data updated?','Dashboard metrics refresh in real-time with each transaction.','Technical',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(102,'How do I refresh settings in the app?','Trigger a refresh via the settings page or API key.','Technical',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(103,'What is a “refresh key”?','It’s a hidden value used internally to update state in real-time.','Technical',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(104,'Are settings synced across users?','Yes, settings apply globally for the app environment.','Technical',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(105,'What are “editable” settings?','Settings marked as editable can be modified by admin users.','Technical',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(106,'Can I change my email or password?','These settings can be updated from your user profile or via admin.','Security',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(107,'What does Treasury Collateral mean?','It reflects security deposits or funds backing your credit usage.','Security',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(108,'What is the Credit Limit?','The maximum amount NodoPay can disburse to vendors on your behalf.','Security',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(109,'Why is my Current Balance different from Available Balance?','Current Balance includes all pending repayments and disbursed amounts.','Security',1,'2025-06-04 06:56:38','2025-06-04 06:56:38'),(110,'What does Available Balance mean?','It’s the total amount currently accessible for funding POs.','Security',1,'2025-06-04 06:56:38','2025-06-04 06:56:38');
/*!40000 ALTER TABLE `faq` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `po_activity_log`
--

DROP TABLE IF EXISTS `po_activity_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `po_activity_log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `purchase_order_id` int(11) NOT NULL,
  `activity_type` enum('Created','Funded','Repaid','StatusUpdate') NOT NULL,
  `notes` text,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `purchase_order_id` (`purchase_order_id`),
  CONSTRAINT `po_activity_log_ibfk_1` FOREIGN KEY (`purchase_order_id`) REFERENCES `purchase_orders` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `po_activity_log`
--

LOCK TABLES `po_activity_log` WRITE;
/*!40000 ALTER TABLE `po_activity_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `po_activity_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `po_statistics_monthly`
--

DROP TABLE IF EXISTS `po_statistics_monthly`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `po_statistics_monthly` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `month` varchar(20) NOT NULL,
  `total_po_value` decimal(18,2) NOT NULL,
  `no_of_pos` int(11) NOT NULL,
  `top_vendor_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `po_statistics_monthly`
--

LOCK TABLES `po_statistics_monthly` WRITE;
/*!40000 ALTER TABLE `po_statistics_monthly` DISABLE KEYS */;
/*!40000 ALTER TABLE `po_statistics_monthly` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `sku` varchar(100) DEFAULT 'N/A',
  `unit_price` decimal(18,2) NOT NULL,
  `unit_of_measure` varchar(50) DEFAULT 'pcs',
  `is_active` tinyint(1) NOT NULL DEFAULT '1',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `sku` (`sku`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,1,'Indomie Noodles Carton','289030JB',25000.00,'Carton',0,'2025-06-08 13:48:34','2025-06-08 13:55:33'),(2,1,'Yam Tuber','ALD930ACV',6000.00,'Tuber',1,'2025-06-08 20:47:24','2025-06-08 20:47:24'),(5,1,'pepper','ALD923ACV',6000.00,'A Cup',1,'2025-06-08 20:47:24','2025-06-08 20:47:24');
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_order_items`
--

DROP TABLE IF EXISTS `purchase_order_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase_order_items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `purchase_order_id` int(11) NOT NULL,
  `product_name` varchar(150) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unit_price` decimal(18,2) NOT NULL,
  `unit_of_measure` varchar(30) NOT NULL,
  `total_price` decimal(18,2) GENERATED ALWAYS AS ((`quantity` * `unit_price`)) STORED,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `purchase_order_id` (`purchase_order_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order_items`
--

LOCK TABLES `purchase_order_items` WRITE;
/*!40000 ALTER TABLE `purchase_order_items` DISABLE KEYS */;
INSERT INTO `purchase_order_items` (`id`, `purchase_order_id`, `product_name`, `quantity`, `unit_price`, `unit_of_measure`, `created_at`) VALUES (3,0,'string',0,0.00,'string','2025-06-10 09:29:24'),(4,0,'Mama gold rice',3,52000.00,'Halg bag','2025-06-10 09:51:48'),(5,0,'Eva bottled water',1,18000.00,'1 Crate','2025-06-10 09:51:48'),(6,10,'Mama gold rice',2,105000.00,'1 bag','2025-06-11 01:46:38'),(7,10,'Pulpy 5 Alive Orange Juice',6,9000.00,'1 Crate','2025-06-11 01:46:38'),(8,0,'string',1,20.00,'string','2025-06-11 14:35:15'),(9,14,'Mama gold rice',1,100000.00,'1 bag','2025-06-11 15:35:36');
/*!40000 ALTER TABLE `purchase_order_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_orders`
--

DROP TABLE IF EXISTS `purchase_orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase_orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `po_code` varchar(50) NOT NULL,
  `vendor_id` int(11) NOT NULL,
  `amount` decimal(18,2) NOT NULL,
  `amount_owed_by_customer` decimal(13,2) NOT NULL,
  `status` enum('Pending','Paid','Owing') NOT NULL,
  `payment_date` date DEFAULT NULL,
  `internal_notes` text,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `repayment_due_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `po_code` (`po_code`),
  KEY `vendor_id` (`vendor_id`),
  CONSTRAINT `purchase_orders_ibfk_1` FOREIGN KEY (`vendor_id`) REFERENCES `vendors` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_orders`
--

LOCK TABLES `purchase_orders` WRITE;
/*!40000 ALTER TABLE `purchase_orders` DISABLE KEYS */;
INSERT INTO `purchase_orders` VALUES (1,1,'PO-0001',1,150000.00,40000.00,'Pending','2025-06-10','First batch of raw materials','2025-06-06 08:32:39','2025-06-07 02:23:37'),(2,1,'PO-0002',2,87500.50,0.00,'Paid','2025-06-01','Express delivery requested','2025-06-06 08:32:39','2025-06-07 02:23:37'),(3,1,'PO-0003',3,223000.75,13000.00,'Pending','2025-06-07','Priority vendor for Q2','2025-06-06 08:32:39','2025-06-07 02:23:37'),(4,1,'PO-0004',1,95000.00,0.00,'Paid','2025-06-07','Incorrect invoice uploaded','2025-06-06 08:32:39','2025-06-07 02:23:37'),(5,1,'PO-0005',4,175000.00,55000.00,'Pending','2025-06-07','Waiting for vendor confirmation','2025-06-06 08:32:39','2025-06-07 02:23:37'),(7,1,'PO-000007',3,300000.00,318000.00,'Pending','2025-06-07','Logi Supply Secial Order','2025-06-07 13:31:39','2025-06-21 13:31:39'),(8,1,'PO-000008',8,287000.00,307664.00,'Pending','2025-06-10','...','2025-06-10 09:10:07','2025-06-25 09:10:07'),(9,1,'PO-000009',8,174000.00,184440.00,'Pending','2025-06-10','Rice and water for Abiye.','2025-06-10 09:51:10','2025-06-25 09:51:10'),(10,1,'PO-000010',8,264000.00,279840.00,'Pending','2025-06-11','Rice and juice for Abiye','2025-06-11 01:46:29','2025-06-26 01:46:29'),(11,1,'PO-000011',8,216000.00,228960.00,'Owing','2025-06-11','Drink and Rice for Abiye','2025-06-11 13:49:25','2025-06-26 13:49:25'),(12,1,'PO-000012',8,210000.00,273000.00,'Owing','2025-06-11','...','2025-06-11 15:09:19','2025-09-09 15:09:19'),(13,1,'PO-000013',2,500.00,510.00,'Owing','2025-06-11','string','2025-06-11 15:23:06','2025-06-11 15:23:06'),(14,1,'PO-000014',8,100000.00,0.00,'Paid','2025-06-11','...','2025-06-11 15:35:28','2025-07-11 15:35:28');
/*!40000 ALTER TABLE `purchase_orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `repayments`
--

DROP TABLE IF EXISTS `repayments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `repayments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `user_business_name` varchar(150) NOT NULL DEFAULT 'N/A',
  `vendor_id` int(11) NOT NULL,
  `purchase_order_id` int(11) NOT NULL,
  `total_po_value` decimal(18,2) NOT NULL,
  `amount_repaid` decimal(18,2) NOT NULL,
  `due_date` date NOT NULL,
  `status` enum('Paid','On Time','Overdue') NOT NULL,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `purchase_order_id` (`purchase_order_id`),
  CONSTRAINT `repayments_ibfk_1` FOREIGN KEY (`purchase_order_id`) REFERENCES `purchase_orders` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `repayments`
--

LOCK TABLES `repayments` WRITE;
/*!40000 ALTER TABLE `repayments` DISABLE KEYS */;
INSERT INTO `repayments` VALUES (1,1,'Abiye Dokubo',1,1,0.00,50000.00,'2025-06-01','Paid','2025-06-06 08:36:37'),(2,1,'Abiye Dokubo',2,2,0.00,87500.50,'2025-06-01','Paid','2025-06-06 08:36:37'),(3,1,'Abiye Dokubo',2,3,0.00,100000.00,'2025-06-03','Paid','2025-06-06 08:36:37'),(4,1,'Abiye Dokubo',5,5,0.00,75000.00,'2025-06-05','Paid','2025-06-06 08:36:37'),(5,1,'Abiye Dokubo',3,1,0.00,100000.00,'2025-06-06','Paid','2025-06-06 08:36:37'),(6,1,'Abiye Dokubo',8,14,100000.00,20000.00,'2025-06-11','Paid','2025-06-11 09:08:43'),(7,1,'Abiye Dokubo',8,14,100000.00,12000.00,'2025-06-11','Paid','2025-06-11 09:18:58'),(8,1,'Abiye Dokubo',8,14,100000.00,78000.00,'2025-06-11','Paid','2025-06-11 09:21:07');
/*!40000 ALTER TABLE `repayments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings`
--

DROP TABLE IF EXISTS `settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `setting_name` varchar(150) NOT NULL,
  `setting_key` varchar(100) NOT NULL,
  `setting_value` text NOT NULL,
  `setting_description` text,
  `setting_datatype` enum('string','number','boolean','datetime','json','big-string','password') NOT NULL DEFAULT 'string',
  `setting_category` varchar(100) DEFAULT NULL,
  `is_editable` tinyint(1) NOT NULL DEFAULT '1',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `setting_key` (`setting_key`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings`
--

LOCK TABLES `settings` WRITE;
/*!40000 ALTER TABLE `settings` DISABLE KEYS */;
INSERT INTO `settings` VALUES (1,'Total Customer Available Balance','total_customer_available_balance','-201010010.00','Total actual amount users can use or withdraw right now.','number','Balance',0,'2025-06-05 22:12:23'),(2,'Total Customer Current Balance','total_customer_current_balance','201210010.00','The total balance of users, including used credit, pending disbursements, and available funds.','number','Balance',0,'2025-06-05 22:12:23'),(3,'Total Customer Collateral Value','total_customer_collateral_value','674100010.00','Total reserve fund or deposit set aside to back user’s credit usage — like a security deposit.','number','Balance',0,'2025-06-05 22:12:23'),(4,'Total Customers','total_customers','4','Total registered users on Nodopay.','number','Analytics',0,'2025-06-05 22:12:23'),(5,'Automated Mailer Email','mailer_email','','Email address used for sending automated mails','string','Email',1,'2025-06-06 03:38:59'),(6,'Automated Mailer Password','mailer_password','','Password used by the automated mailer service','password','Email',1,'2025-06-06 03:38:59'),(7,'Max Vendors Per Customer','max_vendors_per_customer','10','Maximum number of vendors that a customer can manage','number','Customer',1,'2025-06-06 03:38:59'),(8,'Purchase Order Interest','purchase_order_interest','7.5','Interest rate applied to purchase orders (in %)','number','Finance',1,'2025-06-06 03:38:59'),(9,'Admin Notification Email','admin_notification_email','','Where admin-level notifications are sent','string','Notification',1,'2025-06-06 03:38:59'),(10,'Support Whatsapp Number','support_whatsapp','','WhatsApp number for customer support contact','string','Support',1,'2025-06-06 03:38:59'),(11,'Support Email','support_email','','Support team contact email address','string','Support',1,'2025-06-06 03:38:59'),(12,'Company Full Name','company_full_name','NodoPay Ltd.','Official registered name of the company','string','Company',1,'2025-06-06 03:38:59'),(13,'Company Address','company_address','...','Head office or registered address of the company','big-string','Company',1,'2025-06-06 03:38:59'),(14,'About Company','about_company','','Short description about what the company does','big-string','Company',1,'2025-06-06 03:38:59'),(15,'Paystack Secret Key','paystack_sk','sk_live_9aa3137ae81f16d18088350c972835d02076967c','Secret Key used to authenticate secure transactions with Paystack','password','Payment Gateway',1,'2025-06-06 08:31:04'),(16,'Paystack Public Key','paystack_pk','pk_live_3f9a55db51c6af5233a0b0774489b401018b6366','Public Key used on the client-side for initiating Paystack payments','password','Payment Gateway',1,'2025-06-06 08:31:04'),(17,'Minimum Purchase Order Amount','minimum_po_amount','100000','The minimum amount a user can request for a purchase order.','number','Purchase Order',1,'2025-06-07 00:30:33'),(18,'Maximum Purchase Order Amount','maximum_po_amount','10000000','The maximum amount a user can request for a purchase order.','number','Purchase Order',1,'2025-06-07 00:30:33'),(19,'Repayment Interest Percentage','repayment_interest_percentage','6','The interest rate charged on purchase order repayment.','number','Purchase Order',1,'2025-06-07 00:30:33'),(20,'Repayment Interest Growth Factor','repayment_interest_growth_factor','1.2','This object adds value to the repayment interest percentage when the repayment date is more than 2 weeks.','number','Company',1,'2025-06-07 02:12:58'),(21,'Total Credit Limit','total_credit_limit','200000','Total amount of funds users can borrow','number','Company',0,'2025-06-11 04:41:40');
/*!40000 ALTER TABLE `settings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sub_users`
--

DROP TABLE IF EXISTS `sub_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sub_users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password_hash` varchar(20) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_active` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sub_users`
--

LOCK TABLES `sub_users` WRITE;
/*!40000 ALTER TABLE `sub_users` DISABLE KEYS */;
INSERT INTO `sub_users` VALUES (1,1,'ab@a.c','Abcd201d','2025-06-09 21:32:49','2025-06-09 21:32:49',0);
/*!40000 ALTER TABLE `sub_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `support_ticket_logs`
--

DROP TABLE IF EXISTS `support_ticket_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `support_ticket_logs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `support_ticket_id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `log_message` text NOT NULL,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `support_ticket_id` (`support_ticket_id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `support_ticket_logs_ibfk_1` FOREIGN KEY (`support_ticket_id`) REFERENCES `support_tickets` (`id`) ON DELETE CASCADE,
  CONSTRAINT `support_ticket_logs_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `support_ticket_logs`
--

LOCK TABLES `support_ticket_logs` WRITE;
/*!40000 ALTER TABLE `support_ticket_logs` DISABLE KEYS */;
/*!40000 ALTER TABLE `support_ticket_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `support_tickets`
--

DROP TABLE IF EXISTS `support_tickets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `support_tickets` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `subject` varchar(255) NOT NULL,
  `message` text NOT NULL,
  `status` enum('Open','Closed','In Progress') NOT NULL DEFAULT 'Open',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `support_tickets_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `support_tickets`
--

LOCK TABLES `support_tickets` WRITE;
/*!40000 ALTER TABLE `support_tickets` DISABLE KEYS */;
/*!40000 ALTER TABLE `support_tickets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transactions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `reference_code` varchar(100) NOT NULL,
  `purchase_order_id` int(11) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `transaction_type` enum('Funding','Repayment','Adjustment') NOT NULL,
  `amount` decimal(18,2) NOT NULL,
  `description` text,
  `status` enum('Pending','Successful','Failed') NOT NULL DEFAULT 'Pending',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `reference_code` (`reference_code`),
  KEY `purchase_order_id` (`purchase_order_id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`purchase_order_id`) REFERENCES `purchase_orders` (`id`) ON DELETE SET NULL,
  CONSTRAINT `transactions_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `full_name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password_hash` text NOT NULL,
  `transaction_pin` varchar(6) NOT NULL,
  `available_balance` decimal(13,2) NOT NULL DEFAULT '0.00',
  `current_balance` decimal(13,2) NOT NULL DEFAULT '0.00',
  `credit_limit` decimal(13,2) NOT NULL DEFAULT '0.00',
  `collateral_value` decimal(13,2) NOT NULL DEFAULT '0.00',
  `role` enum('admin','customer') NOT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT '1',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Abiye Dokubo','abdokubo@gmail.com','Abcd1234@','',946000.00,1210000.00,2000000.00,100000.00,'customer',1,'2025-06-07 02:42:21','2025-06-07 02:42:21'),(2,'FoodStuff Store','admin@foodstuff.store','Abcd1234?','',120000000.00,200000000.00,320000000.00,640000000.00,'customer',1,'2025-06-05 06:04:48','2025-06-07 13:53:16'),(4,'Ordali Ai','admin@ordali.foodstuff.store','','',10.00,10.00,10.00,10.00,'customer',1,'2025-06-06 06:57:40','2025-06-06 07:34:40'),(5,'Nodopay Admin 1','admin1@nodopay.com','Abcd1234@','1234',0.00,0.00,0.00,0.00,'admin',1,'2025-06-11 08:43:44','2025-06-11 08:43:44'),(6,'Faceboo Ltd','mark@facebook.com','','',13000000.00,0.00,13000000.00,14000000.00,'customer',1,'2025-06-11 16:33:17','2025-06-11 16:39:01'),(7,'Twitter Ltd','admin@twitter.com','7fsb2d0%_IXj','1234',20000000.00,0.00,20000000.00,20000000.00,'customer',1,'2025-06-11 16:41:38','2025-06-11 16:41:38');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendors`
--

DROP TABLE IF EXISTS `vendors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendors` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `bank_account_no` varchar(100) NOT NULL,
  `bank_name` varchar(255) NOT NULL,
  `total_paid_po` int(11) NOT NULL DEFAULT '0',
  `total_owing_po` int(11) NOT NULL DEFAULT '0',
  `sum_of_paid_po` decimal(18,2) NOT NULL DEFAULT '0.00',
  `sum_of_pending_po` decimal(18,2) NOT NULL DEFAULT '0.00',
  `is_verified` tinyint(1) NOT NULL DEFAULT '0',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendors`
--

LOCK TABLES `vendors` WRITE;
/*!40000 ALTER TABLE `vendors` DISABLE KEYS */;
INSERT INTO `vendors` VALUES (1,1,'FarmFresh Ltd.','1234567890','First Bank',0,0,0.00,0.00,0,'2025-06-06 08:27:08'),(2,1,'GreenHarvest Co.','2345678901','GTBank',0,0,0.00,0.00,0,'2025-06-06 08:27:08'),(3,1,'LogiSupply Inc.','3456789012','Access Bank',0,0,0.00,0.00,0,'2025-06-06 08:27:08'),(4,1,'MegaAgro Ventures','4567890123','UBA',0,0,0.00,0.00,0,'2025-06-06 08:27:08'),(5,1,'PrimeProduce NG','5678901234','Zenith Bank',0,0,0.00,0.00,0,'2025-06-06 08:27:08'),(8,1,'ABIYE SAMUEL DOKUBO','0033250309','Stanbic IBTC Bank',0,0,0.00,0.00,1,'2025-06-07 13:36:28');
/*!40000 ALTER TABLE `vendors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'db_a68892_nodopay'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-11 10:02:19
