CREATE DATABASE  IF NOT EXISTS `motel_managment` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `motel_managment`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: motel_managment
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `people`
--

DROP TABLE IF EXISTS `people`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `people` (
  `person_id` varchar(45) NOT NULL,
  `person_name` varchar(255) NOT NULL,
  `person_address` varchar(255) NOT NULL,
  `person_phone_number` varchar(45) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `describe` varchar(255) DEFAULT 'custom',
  `room_id` varchar(45) NOT NULL,
  PRIMARY KEY (`person_id`),
  UNIQUE KEY `admin_id_UNIQUE` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `people`
--

LOCK TABLES `people` WRITE;
/*!40000 ALTER TABLE `people` DISABLE KEYS */;
INSERT INTO `people` VALUES ('2','Đoàn Quang Huy','Hải Dương','0395018203','huy123','12345','custom','1'),('3','Lê Duy','Hà Nội','0123455675','duy123','12345','custom','1'),('4','Nguyễn Văn A','Hà Nội','1234567890','a1234','12345','custom','1'),('5','Nguyễn Văn B','Hà Nội','7242429423','b1234','12345','custom','2'),('6','Minh Nguyễn','Thanh Hóa','0936457123','minhdt1102','12345','custom','2'),('7','admin','Ha Noi','0987654321','admin','12345','admin','1'),('8','Nguyen van c','hai duong','1324234244','c1234','12345','custom','2'),('9','ad','da','ad','da','daa','custom','');
/*!40000 ALTER TABLE `people` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `room`
--

DROP TABLE IF EXISTS `room`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `room` (
  `room_id` varchar(45) NOT NULL,
  `start_date` varchar(45) DEFAULT '00/00/0000',
  `end_date` varchar(45) DEFAULT '00/00/0000',
  `e_price` double DEFAULT NULL,
  `w_price` double DEFAULT NULL,
  `s_price` double DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `r_price` double DEFAULT NULL,
  PRIMARY KEY (`room_id`),
  UNIQUE KEY `rom_id_UNIQUE` (`room_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `room`
--

LOCK TABLES `room` WRITE;
/*!40000 ALTER TABLE `room` DISABLE KEYS */;
INSERT INTO `room` VALUES ('1','18/08/2022','18/11/2022',3500,28000,200000,'used',1500000),('2','03/07/2022','03/10/2022',3500,26000,150000,'used',1900000),('3','00/00/0000','00/00/0000',1600,12000,110000,'trong',5000000),('4','00/00/0000','00/00/0000',5000,30000,10000,'trong',1000000),('5','00/00/0000','00/00/0000',2000,15000,10000,'trong',4000000),('6','00/00/0000','00/00/0000',2000,10000,50000,'trong',2000000),('7','00/00/0000','00/00/0000',3000,10000,40000,'trong',2500000);
/*!40000 ALTER TABLE `room` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-10-07 14:01:47
