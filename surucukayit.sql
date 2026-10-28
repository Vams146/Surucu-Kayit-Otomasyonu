-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: surucukayit
-- ------------------------------------------------------
-- Server version	8.0.37

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
-- Table structure for table `adaylar`
--

DROP TABLE IF EXISTS `adaylar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `adaylar` (
  `idadaylar` int NOT NULL AUTO_INCREMENT,
  `aday_tc` varchar(11) DEFAULT NULL,
  `aday_ad` varchar(45) DEFAULT NULL,
  `aday_soyad` varchar(45) DEFAULT NULL,
  `aday_yas` varchar(4) DEFAULT NULL,
  `aday_od` varchar(17) DEFAULT NULL,
  `aday_tel` varchar(45) DEFAULT NULL,
  `aday_sr` varchar(4) DEFAULT NULL,
  `aday_ab` varchar(4) DEFAULT NULL,
  `aday_kt` varchar(45) DEFAULT NULL,
  `aday_e_s` varchar(4) DEFAULT NULL,
  `aday_res` varchar(150) DEFAULT NULL,
  `aday_k_s` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idadaylar`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adaylar`
--

LOCK TABLES `adaylar` WRITE;
/*!40000 ALTER TABLE `adaylar` DISABLE KEYS */;
/*!40000 ALTER TABLE `adaylar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `guvenlik`
--

DROP TABLE IF EXISTS `guvenlik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `guvenlik` (
  `idguvenlik` int NOT NULL AUTO_INCREMENT,
  `guv_soru` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idguvenlik`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `guvenlik`
--

LOCK TABLES `guvenlik` WRITE;
/*!40000 ALTER TABLE `guvenlik` DISABLE KEYS */;
INSERT INTO `guvenlik` VALUES (1,'İlk evcil hayvanınız ?'),(2,'İlkokulunuz ?'),(3,'Kaç kardeşiniz var ?'),(4,'Annenizin kızlık soyadı ?');
/*!40000 ALTER TABLE `guvenlik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kimlik`
--

DROP TABLE IF EXISTS `kimlik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kimlik` (
  `idkimlik` int NOT NULL AUTO_INCREMENT,
  `tc` varchar(11) DEFAULT NULL,
  `soyad` varchar(45) DEFAULT NULL,
  `ad` varchar(45) DEFAULT NULL,
  `dogum_tarihi` varchar(45) DEFAULT NULL,
  `seri_no` varchar(9) DEFAULT NULL,
  `cinsiyet` varchar(5) DEFAULT NULL,
  `anne_ad` varchar(45) DEFAULT NULL,
  `baba_ad` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idkimlik`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kimlik`
--

LOCK TABLES `kimlik` WRITE;
/*!40000 ALTER TABLE `kimlik` DISABLE KEYS */;
/*!40000 ALTER TABLE `kimlik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notlar`
--

DROP TABLE IF EXISTS `notlar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notlar` (
  `idnot` int NOT NULL AUTO_INCREMENT,
  `aday_tc` varchar(11) DEFAULT NULL,
  `aday_ad` varchar(45) DEFAULT NULL,
  `aday_soyad` varchar(45) DEFAULT NULL,
  `sınav_tarihi` varchar(45) DEFAULT NULL,
  `trafik_s_not` varchar(3) DEFAULT NULL,
  `motor_s_not` varchar(3) DEFAULT NULL,
  `ilk_yardım_s_not` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`idnot`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notlar`
--

LOCK TABLES `notlar` WRITE;
/*!40000 ALTER TABLE `notlar` DISABLE KEYS */;
/*!40000 ALTER TABLE `notlar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personel`
--

DROP TABLE IF EXISTS `personel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personel` (
  `idpersonel` int NOT NULL AUTO_INCREMENT,
  `per_tc` varchar(11) DEFAULT NULL,
  `per_ad` varchar(45) DEFAULT NULL,
  `per_soyad` varchar(45) DEFAULT NULL,
  `per_tel` varchar(45) DEFAULT NULL,
  `per_adres` varchar(100) DEFAULT NULL,
  `per_pos` varchar(100) DEFAULT NULL,
  `per_gor` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idpersonel`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personel`
--

LOCK TABLES `personel` WRITE;
/*!40000 ALTER TABLE `personel` DISABLE KEYS */;
/*!40000 ALTER TABLE `personel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `uyelik`
--

DROP TABLE IF EXISTS `uyelik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `uyelik` (
  `iduyelik` int NOT NULL AUTO_INCREMENT,
  `ad` varchar(45) DEFAULT NULL,
  `soyad` varchar(45) DEFAULT NULL,
  `e_posta` varchar(100) DEFAULT NULL,
  `k_adi` varchar(50) DEFAULT NULL,
  `sifre` varchar(50) DEFAULT NULL,
  `guv_soru` varchar(100) DEFAULT NULL,
  `cevap` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`iduyelik`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uyelik`
--

LOCK TABLES `uyelik` WRITE;
/*!40000 ALTER TABLE `uyelik` DISABLE KEYS */;
/*!40000 ALTER TABLE `uyelik` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-01 17:45:30
