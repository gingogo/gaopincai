/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50532
Source Host           : localhost:3306
Source Database       : lotteryjiangx115

Target Server Type    : MYSQL
Target Server Version : 50532
File Encoding         : 65001

Date: 2013-07-06 15:13:32
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for dmc2
-- ----------------------------
DROP TABLE IF EXISTS `dmc2`;
CREATE TABLE `dmc2` (
  `Id` char(4) NOT NULL,
  `NumberType` char(2) NOT NULL,
  `Number` char(5) NOT NULL,
  `DaXiao` char(3) NOT NULL,
  `DanShuang` char(3) NOT NULL,
  `ZiHe` char(3) NOT NULL,
  `Lu012` char(3) NOT NULL,
  `He` int(11) NOT NULL,
  `HeWei` int(11) NOT NULL,
  `DaCnt` int(11) NOT NULL,
  `XiaoCnt` int(11) NOT NULL,
  `DanCnt` int(11) NOT NULL,
  `ShuangCnt` int(11) NOT NULL,
  `ZiCnt` int(11) NOT NULL,
  `HeCnt` int(11) NOT NULL,
  `Lu0Cnt` int(11) NOT NULL,
  `Lu1Cnt` int(11) NOT NULL,
  `Lu2Cnt` int(11) NOT NULL,
  `Ji` int(11) NOT NULL,
  `JiWei` int(11) NOT NULL,
  `KuaDu` int(11) NOT NULL,
  `AC` int(11) NOT NULL,
  `DaXiaoBi` char(3) NOT NULL,
  `ZiHeBi` char(3) NOT NULL,
  `DanShuangBi` char(3) NOT NULL,
  `Lu012Bi` char(5) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dmc3
-- ----------------------------
DROP TABLE IF EXISTS `dmc3`;
CREATE TABLE `dmc3` (
  `Id` char(6) NOT NULL,
  `NumberType` char(2) NOT NULL,
  `Number` char(8) NOT NULL,
  `DaXiao` char(5) NOT NULL,
  `DanShuang` char(5) NOT NULL,
  `ZiHe` char(5) NOT NULL,
  `Lu012` char(5) NOT NULL,
  `He` int(11) NOT NULL,
  `HeWei` int(11) NOT NULL,
  `DaCnt` int(11) NOT NULL,
  `XiaoCnt` int(11) NOT NULL,
  `DanCnt` int(11) NOT NULL,
  `ShuangCnt` int(11) NOT NULL,
  `ZiCnt` int(11) NOT NULL,
  `HeCnt` int(11) NOT NULL,
  `Lu0Cnt` int(11) NOT NULL,
  `Lu1Cnt` int(11) NOT NULL,
  `Lu2Cnt` int(11) NOT NULL,
  `Ji` int(11) NOT NULL,
  `JiWei` int(11) NOT NULL,
  `KuaDu` int(11) NOT NULL,
  `AC` int(11) NOT NULL,
  `DaXiaoBi` char(3) NOT NULL,
  `ZiHeBi` char(3) NOT NULL,
  `DanShuangBi` char(3) NOT NULL,
  `Lu012Bi` char(5) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dmc4
-- ----------------------------
DROP TABLE IF EXISTS `dmc4`;
CREATE TABLE `dmc4` (
  `Id` char(8) NOT NULL,
  `NumberType` char(2) NOT NULL,
  `Number` char(11) NOT NULL,
  `DaXiao` char(7) NOT NULL,
  `DanShuang` char(7) NOT NULL,
  `ZiHe` char(7) NOT NULL,
  `Lu012` char(7) NOT NULL,
  `He` int(11) NOT NULL,
  `HeWei` int(11) NOT NULL,
  `DaCnt` int(11) NOT NULL,
  `XiaoCnt` int(11) NOT NULL,
  `DanCnt` int(11) NOT NULL,
  `ShuangCnt` int(11) NOT NULL,
  `ZiCnt` int(11) NOT NULL,
  `HeCnt` int(11) NOT NULL,
  `Lu0Cnt` int(11) NOT NULL,
  `Lu1Cnt` int(11) NOT NULL,
  `Lu2Cnt` int(11) NOT NULL,
  `Ji` int(11) NOT NULL,
  `JiWei` int(11) NOT NULL,
  `KuaDu` int(11) NOT NULL,
  `AC` int(11) NOT NULL,
  `DaXiaoBi` char(3) NOT NULL,
  `ZiHeBi` char(3) NOT NULL,
  `DanShuangBi` char(3) NOT NULL,
  `Lu012Bi` char(5) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dmc5
-- ----------------------------
DROP TABLE IF EXISTS `dmc5`;
CREATE TABLE `dmc5` (
  `Id` char(10) NOT NULL,
  `NumberType` char(2) NOT NULL,
  `Number` char(14) NOT NULL,
  `DaXiao` char(9) NOT NULL,
  `DanShuang` char(9) NOT NULL,
  `ZiHe` char(9) NOT NULL,
  `Lu012` char(9) NOT NULL,
  `He` int(11) NOT NULL,
  `HeWei` int(11) NOT NULL,
  `DaCnt` int(11) NOT NULL,
  `XiaoCnt` int(11) NOT NULL,
  `DanCnt` int(11) NOT NULL,
  `ShuangCnt` int(11) NOT NULL,
  `ZiCnt` int(11) NOT NULL,
  `HeCnt` int(11) NOT NULL,
  `Lu0Cnt` int(11) NOT NULL,
  `Lu1Cnt` int(11) NOT NULL,
  `Lu2Cnt` int(11) NOT NULL,
  `Ji` int(11) NOT NULL,
  `JiWei` int(11) NOT NULL,
  `KuaDu` int(11) NOT NULL,
  `AC` int(11) NOT NULL,
  `DaXiaoBi` char(3) NOT NULL,
  `ZiHeBi` char(3) NOT NULL,
  `DanShuangBi` char(3) NOT NULL,
  `Lu012Bi` char(5) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dmc5cx
-- ----------------------------
DROP TABLE IF EXISTS `dmc5cx`;
CREATE TABLE `dmc5cx` (
  `C5` char(10) NOT NULL,
  `CX` varchar(16) NOT NULL,
  `C5Number` char(14) NOT NULL,
  `CXNumber` varchar(23) NOT NULL,
  `NumberType` char(2) NOT NULL,
  PRIMARY KEY (`C5`,`CX`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dmc6
-- ----------------------------
DROP TABLE IF EXISTS `dmc6`;
CREATE TABLE `dmc6` (
  `Id` char(12) NOT NULL,
  `NumberType` char(2) NOT NULL,
  `Number` char(17) NOT NULL,
  `DaXiao` char(11) NOT NULL,
  `DanShuang` char(11) NOT NULL,
  `ZiHe` char(11) NOT NULL,
  `Lu012` char(11) NOT NULL,
  `He` int(11) NOT NULL,
  `HeWei` int(11) NOT NULL,
  `DaCnt` int(11) NOT NULL,
  `XiaoCnt` int(11) NOT NULL,
  `DanCnt` int(11) NOT NULL,
  `ShuangCnt` int(11) NOT NULL,
  `ZiCnt` int(11) NOT NULL,
  `HeCnt` int(11) NOT NULL,
  `Lu0Cnt` int(11) NOT NULL,
  `Lu1Cnt` int(11) NOT NULL,
  `Lu2Cnt` int(11) NOT NULL,
  `Ji` int(11) NOT NULL,
  `JiWei` int(11) NOT NULL,
  `KuaDu` int(11) NOT NULL,
  `AC` int(11) NOT NULL,
  `DaXiaoBi` char(3) NOT NULL,
  `ZiHeBi` char(3) NOT NULL,
  `DanShuangBi` char(3) NOT NULL,
  `Lu012Bi` char(5) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dmc7
-- ----------------------------
DROP TABLE IF EXISTS `dmc7`;
CREATE TABLE `dmc7` (
  `Id` char(14) NOT NULL,
  `NumberType` char(2) NOT NULL,
  `Number` char(20) NOT NULL,
  `DaXiao` char(13) NOT NULL,
  `DanShuang` char(13) NOT NULL,
  `ZiHe` char(13) NOT NULL,
  `Lu012` char(13) NOT NULL,
  `He` int(11) NOT NULL,
  `HeWei` int(11) NOT NULL,
  `DaCnt` int(11) NOT NULL,
  `XiaoCnt` int(11) NOT NULL,
  `DanCnt` int(11) NOT NULL,
  `ShuangCnt` int(11) NOT NULL,
  `ZiCnt` int(11) NOT NULL,
  `HeCnt` int(11) NOT NULL,
  `Lu0Cnt` int(11) NOT NULL,
  `Lu1Cnt` int(11) NOT NULL,
  `Lu2Cnt` int(11) NOT NULL,
  `Ji` int(11) NOT NULL,
  `JiWei` int(11) NOT NULL,
  `KuaDu` int(11) NOT NULL,
  `AC` int(11) NOT NULL,
  `DaXiaoBi` char(3) NOT NULL,
  `ZiHeBi` char(3) NOT NULL,
  `DanShuangBi` char(3) NOT NULL,
  `Lu012Bi` char(5) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dmc8
-- ----------------------------
DROP TABLE IF EXISTS `dmc8`;
CREATE TABLE `dmc8` (
  `Id` char(16) NOT NULL,
  `NumberType` char(2) NOT NULL,
  `Number` char(23) NOT NULL,
  `DaXiao` char(15) NOT NULL,
  `DanShuang` char(15) NOT NULL,
  `ZiHe` char(15) NOT NULL,
  `Lu012` char(15) NOT NULL,
  `He` int(11) NOT NULL,
  `HeWei` int(11) NOT NULL,
  `DaCnt` int(11) NOT NULL,
  `XiaoCnt` int(11) NOT NULL,
  `DanCnt` int(11) NOT NULL,
  `ShuangCnt` int(11) NOT NULL,
  `ZiCnt` int(11) NOT NULL,
  `HeCnt` int(11) NOT NULL,
  `Lu0Cnt` int(11) NOT NULL,
  `Lu1Cnt` int(11) NOT NULL,
  `Lu2Cnt` int(11) NOT NULL,
  `Ji` int(11) NOT NULL,
  `JiWei` int(11) NOT NULL,
  `KuaDu` int(11) NOT NULL,
  `AC` int(11) NOT NULL,
  `DaXiaoBi` char(3) NOT NULL,
  `ZiHeBi` char(3) NOT NULL,
  `DanShuangBi` char(3) NOT NULL,
  `Lu012Bi` char(5) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dmdx
-- ----------------------------
DROP TABLE IF EXISTS `dmdx`;
CREATE TABLE `dmdx` (
  `Id` char(2) NOT NULL,
  `NumberType` char(2) NOT NULL,
  `Number` char(2) NOT NULL,
  `DaXiao` char(1) NOT NULL,
  `DanShuang` char(1) NOT NULL,
  `ZiHe` char(1) NOT NULL,
  `Lu012` char(1) NOT NULL,
  `He` int(11) NOT NULL,
  `HeWei` int(11) NOT NULL,
  `DaCnt` int(11) NOT NULL,
  `XiaoCnt` int(11) NOT NULL,
  `DanCnt` int(11) NOT NULL,
  `ShuangCnt` int(11) NOT NULL,
  `ZiCnt` int(11) NOT NULL,
  `HeCnt` int(11) NOT NULL,
  `Lu0Cnt` int(11) NOT NULL,
  `Lu1Cnt` int(11) NOT NULL,
  `Lu2Cnt` int(11) NOT NULL,
  `Ji` int(11) NOT NULL,
  `JiWei` int(11) NOT NULL,
  `KuaDu` int(11) NOT NULL,
  `AC` int(11) NOT NULL,
  `DaXiaoBi` char(3) NOT NULL,
  `ZiHeBi` char(3) NOT NULL,
  `DanShuangBi` char(3) NOT NULL,
  `Lu012Bi` char(5) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dmp2
-- ----------------------------
DROP TABLE IF EXISTS `dmp2`;
CREATE TABLE `dmp2` (
  `Id` char(4) NOT NULL,
  `NumberType` char(2) NOT NULL,
  `Number` char(5) NOT NULL,
  `DaXiao` char(3) NOT NULL,
  `DanShuang` char(3) NOT NULL,
  `ZiHe` char(3) NOT NULL,
  `Lu012` char(3) NOT NULL,
  `He` int(11) NOT NULL,
  `HeWei` int(11) NOT NULL,
  `DaCnt` int(11) NOT NULL,
  `XiaoCnt` int(11) NOT NULL,
  `DanCnt` int(11) NOT NULL,
  `ShuangCnt` int(11) NOT NULL,
  `ZiCnt` int(11) NOT NULL,
  `HeCnt` int(11) NOT NULL,
  `Lu0Cnt` int(11) NOT NULL,
  `Lu1Cnt` int(11) NOT NULL,
  `Lu2Cnt` int(11) NOT NULL,
  `Ji` int(11) NOT NULL,
  `JiWei` int(11) NOT NULL,
  `KuaDu` int(11) NOT NULL,
  `AC` int(11) NOT NULL,
  `DaXiaoBi` char(3) NOT NULL,
  `ZiHeBi` char(3) NOT NULL,
  `DanShuangBi` char(3) NOT NULL,
  `Lu012Bi` char(5) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dmp3
-- ----------------------------
DROP TABLE IF EXISTS `dmp3`;
CREATE TABLE `dmp3` (
  `Id` char(6) NOT NULL,
  `NumberType` char(2) NOT NULL,
  `Number` char(8) NOT NULL,
  `DaXiao` char(5) NOT NULL,
  `DanShuang` char(5) NOT NULL,
  `ZiHe` char(5) NOT NULL,
  `Lu012` char(5) NOT NULL,
  `He` int(11) NOT NULL,
  `HeWei` int(11) NOT NULL,
  `DaCnt` int(11) NOT NULL,
  `XiaoCnt` int(11) NOT NULL,
  `DanCnt` int(11) NOT NULL,
  `ShuangCnt` int(11) NOT NULL,
  `ZiCnt` int(11) NOT NULL,
  `HeCnt` int(11) NOT NULL,
  `Lu0Cnt` int(11) NOT NULL,
  `Lu1Cnt` int(11) NOT NULL,
  `Lu2Cnt` int(11) NOT NULL,
  `Ji` int(11) NOT NULL,
  `JiWei` int(11) NOT NULL,
  `KuaDu` int(11) NOT NULL,
  `AC` int(11) NOT NULL,
  `DaXiaoBi` char(3) NOT NULL,
  `ZiHeBi` char(3) NOT NULL,
  `DanShuangBi` char(3) NOT NULL,
  `Lu012Bi` char(5) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwacspan
-- ----------------------------
DROP TABLE IF EXISTS `dwacspan`;
CREATE TABLE `dwacspan` (
  `P` bigint(20) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwc5c2span
-- ----------------------------
DROP TABLE IF EXISTS `dwc5c2span`;
CREATE TABLE `dwc5c2span` (
  `P` bigint(20) NOT NULL,
  `C5` char(10) NOT NULL,
  `CX` char(4) NOT NULL,
  `Seq` int(11) NOT NULL,
  `PeroidSpans` int(11) NOT NULL,
  `HeSpans` int(11) NOT NULL,
  PRIMARY KEY (`P`,`C5`,`CX`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwc5c3span
-- ----------------------------
DROP TABLE IF EXISTS `dwc5c3span`;
CREATE TABLE `dwc5c3span` (
  `P` bigint(20) NOT NULL,
  `C5` char(10) NOT NULL,
  `CX` char(6) NOT NULL,
  `Seq` int(11) NOT NULL,
  `PeroidSpans` int(11) NOT NULL,
  `HeSpans` int(11) NOT NULL,
  PRIMARY KEY (`P`,`C5`,`CX`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwc5c4span
-- ----------------------------
DROP TABLE IF EXISTS `dwc5c4span`;
CREATE TABLE `dwc5c4span` (
  `P` bigint(20) NOT NULL,
  `C5` char(10) NOT NULL,
  `CX` char(8) NOT NULL,
  `Seq` int(11) NOT NULL,
  `PeroidSpans` int(11) NOT NULL,
  `HeSpans` int(11) NOT NULL,
  PRIMARY KEY (`P`,`C5`,`CX`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwc5c6span
-- ----------------------------
DROP TABLE IF EXISTS `dwc5c6span`;
CREATE TABLE `dwc5c6span` (
  `P` bigint(20) NOT NULL,
  `C5` char(10) NOT NULL,
  `CX` char(12) NOT NULL,
  `Seq` int(11) NOT NULL,
  `PeroidSpans` int(11) NOT NULL,
  `HeSpans` int(11) NOT NULL,
  PRIMARY KEY (`P`,`C5`,`CX`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwc5c7span
-- ----------------------------
DROP TABLE IF EXISTS `dwc5c7span`;
CREATE TABLE `dwc5c7span` (
  `P` bigint(20) NOT NULL,
  `C5` char(10) NOT NULL,
  `CX` char(14) NOT NULL,
  `Seq` int(11) NOT NULL,
  `PeroidSpans` int(11) NOT NULL,
  `HeSpans` int(11) NOT NULL,
  PRIMARY KEY (`P`,`C5`,`CX`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwc5c8span
-- ----------------------------
DROP TABLE IF EXISTS `dwc5c8span`;
CREATE TABLE `dwc5c8span` (
  `P` bigint(20) NOT NULL,
  `C5` char(10) NOT NULL,
  `CX` char(16) NOT NULL,
  `Seq` int(11) NOT NULL,
  `PeroidSpans` int(11) NOT NULL,
  `HeSpans` int(11) NOT NULL,
  PRIMARY KEY (`P`,`C5`,`CX`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwdanshuangbispan
-- ----------------------------
DROP TABLE IF EXISTS `dwdanshuangbispan`;
CREATE TABLE `dwdanshuangbispan` (
  `P` bigint(20) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwdanshuangspan
-- ----------------------------
DROP TABLE IF EXISTS `dwdanshuangspan`;
CREATE TABLE `dwdanshuangspan` (
  `P` bigint(20) NOT NULL,
  `D1Spans` int(11) NOT NULL,
  `D2Spans` int(11) NOT NULL,
  `D3Spans` int(11) NOT NULL,
  `D4Spans` int(11) NOT NULL,
  `D5Spans` int(11) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwdaxiaobispan
-- ----------------------------
DROP TABLE IF EXISTS `dwdaxiaobispan`;
CREATE TABLE `dwdaxiaobispan` (
  `P` bigint(20) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwdaxiaospan
-- ----------------------------
DROP TABLE IF EXISTS `dwdaxiaospan`;
CREATE TABLE `dwdaxiaospan` (
  `P` bigint(20) NOT NULL,
  `D1Spans` int(11) NOT NULL,
  `D2Spans` int(11) NOT NULL,
  `D3Spans` int(11) NOT NULL,
  `D4Spans` int(11) NOT NULL,
  `D5Spans` int(11) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwhespan
-- ----------------------------
DROP TABLE IF EXISTS `dwhespan`;
CREATE TABLE `dwhespan` (
  `P` bigint(20) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwheweispan
-- ----------------------------
DROP TABLE IF EXISTS `dwheweispan`;
CREATE TABLE `dwheweispan` (
  `P` bigint(20) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwjispan
-- ----------------------------
DROP TABLE IF EXISTS `dwjispan`;
CREATE TABLE `dwjispan` (
  `P` bigint(20) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwjiweispan
-- ----------------------------
DROP TABLE IF EXISTS `dwjiweispan`;
CREATE TABLE `dwjiweispan` (
  `P` bigint(20) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwkuaduspan
-- ----------------------------
DROP TABLE IF EXISTS `dwkuaduspan`;
CREATE TABLE `dwkuaduspan` (
  `P` bigint(20) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwlu012bispan
-- ----------------------------
DROP TABLE IF EXISTS `dwlu012bispan`;
CREATE TABLE `dwlu012bispan` (
  `P` bigint(20) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwlu012span
-- ----------------------------
DROP TABLE IF EXISTS `dwlu012span`;
CREATE TABLE `dwlu012span` (
  `P` bigint(20) NOT NULL,
  `D1Spans` int(11) NOT NULL,
  `D2Spans` int(11) NOT NULL,
  `D3Spans` int(11) NOT NULL,
  `D4Spans` int(11) NOT NULL,
  `D5Spans` int(11) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwnumber
-- ----------------------------
DROP TABLE IF EXISTS `dwnumber`;
CREATE TABLE `dwnumber` (
  `P` bigint(20) NOT NULL,
  `D1` int(11) NOT NULL,
  `D2` int(11) NOT NULL,
  `D3` int(11) NOT NULL,
  `D4` int(11) NOT NULL,
  `D5` int(11) NOT NULL,
  `P2` char(4) NOT NULL,
  `C2` char(4) NOT NULL,
  `P3` char(6) NOT NULL,
  `C3` char(6) NOT NULL,
  `P5` char(10) NOT NULL,
  `C5` char(10) NOT NULL,
  `N` int(11) NOT NULL,
  `Seq` int(11) NOT NULL,
  `Date` int(11) NOT NULL,
  `Created` datetime NOT NULL,
  PRIMARY KEY (`P`),
  KEY `IX_DwNumber_Seq` (`Seq`) USING HASH,
  KEY `IX_DwNumber_Date` (`Date`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwperoidspan
-- ----------------------------
DROP TABLE IF EXISTS `dwperoidspan`;
CREATE TABLE `dwperoidspan` (
  `P` bigint(20) NOT NULL,
  `D1Spans` int(11) NOT NULL,
  `D2Spans` int(11) NOT NULL,
  `D3Spans` int(11) NOT NULL,
  `D4Spans` int(11) NOT NULL,
  `D5Spans` int(11) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwzihebispan
-- ----------------------------
DROP TABLE IF EXISTS `dwzihebispan`;
CREATE TABLE `dwzihebispan` (
  `P` bigint(20) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dwzihespan
-- ----------------------------
DROP TABLE IF EXISTS `dwzihespan`;
CREATE TABLE `dwzihespan` (
  `P` bigint(20) NOT NULL,
  `D1Spans` int(11) NOT NULL,
  `D2Spans` int(11) NOT NULL,
  `D3Spans` int(11) NOT NULL,
  `D4Spans` int(11) NOT NULL,
  `D5Spans` int(11) NOT NULL,
  `P2Spans` int(11) NOT NULL,
  `C2Spans` int(11) NOT NULL,
  `P3Spans` int(11) NOT NULL,
  `C3Spans` int(11) NOT NULL,
  `C5Spans` int(11) NOT NULL,
  PRIMARY KEY (`P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
