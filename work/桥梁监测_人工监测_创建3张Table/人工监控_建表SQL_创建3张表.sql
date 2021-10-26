-- --------------------------------------------------------
-- 主机:                           127.0.0.1
-- 服务器版本:                        5.7.30 - MySQL Community Server (GPL)
-- 服务器操作系统:                      Win64
-- HeidiSQL 版本:                  11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- 导出  表 gdbs_dev.bge_manual_monitor 结构
CREATE TABLE IF NOT EXISTS `bge_manual_monitor` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `bge_id` int(11) DEFAULT NULL COMMENT '桥梁id',
  `bge_name` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '桥梁名称',
  `ver_name` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '版本名称，格式为“2013-03-18”',
  `monitor_time` datetime DEFAULT NULL COMMENT '监测时间 输出给前端格式为"2021-05-08"',
  `naodu_over` int(1) DEFAULT '0' COMMENT '挠度是否超限，1 是，0 否',
  `bianxing_over` int(1) DEFAULT '0' COMMENT '主要受力构件结构变形变位是否超限，1 是，0 否',
  `upload_file_url` varchar(500) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '上传的相关报告附件，格式:.rar .zip .doc .docx .pdf .jpg',
  `upload_img_url` varchar(500) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '上传的“布点图”, 格式: .png .jpg',
  `upload_time` datetime DEFAULT NULL COMMENT '上传时间',
  `company_name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '监测单位名称',
  `company_id` int(11) DEFAULT NULL COMMENT '监测单位ID',
  `create_userid` int(11) DEFAULT NULL COMMENT '创建用户',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `is_deleted` int(1) DEFAULT '0' COMMENT '是否删除,0为未删除，1为已删除，默认为0',
  `delete_userid` int(11) DEFAULT NULL COMMENT '删除人id',
  `delete_time` datetime DEFAULT NULL COMMENT '删除时间',
  `update_userid` int(11) DEFAULT NULL COMMENT '修改人id',
  `update_time` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `bge_id` (`bge_id`)
) ENGINE=MyISAM AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='桥梁监测--->人工监测，测点版本数据主表';

-- 正在导出表  gdbs_dev.bge_manual_monitor 的数据：10 rows
/*!40000 ALTER TABLE `bge_manual_monitor` DISABLE KEYS */;
INSERT INTO `bge_manual_monitor` (`id`, `bge_id`, `bge_name`, `ver_name`, `monitor_time`, `naodu_over`, `bianxing_over`, `upload_file_url`, `upload_img_url`, `upload_time`, `company_name`, `company_id`, `create_userid`, `create_time`, `is_deleted`, `delete_userid`, `delete_time`, `update_userid`, `update_time`) VALUES
	(1, 110, '黄沙河桥', '2017-03-15', '2017-03-15 09:14:47', 0, 0, NULL, NULL, '2017-03-15 09:14:47', '东莞市常平镇12某单位test', 112, 46, '2021-10-26 18:33:38', 0, NULL, NULL, NULL, NULL),
	(2, 110, '黄沙河桥', '2018-07-20', '2018-07-20 10:26:09', 0, 0, NULL, NULL, '2018-07-20 10:26:09', '东莞市常平镇12某单位test', 112, 46, '2021-10-26 18:33:40', 0, NULL, NULL, NULL, NULL),
	(3, 110, '黄沙河桥', '2017-06-11', '2017-06-11 13:32:30', 0, 0, NULL, NULL, '2017-06-11 13:32:30', '东莞市常平镇12某单位test', 112, 46, '2021-10-26 18:33:40', 0, NULL, NULL, NULL, NULL),
	(4, 110, '黄沙河桥', '2018-06-15', '2018-06-15 11:26:45', 0, 0, NULL, NULL, '2018-06-15 11:26:45', '东莞市常平镇12某单位test', 112, 46, '2021-10-26 18:33:41', 0, NULL, NULL, NULL, NULL),
	(5, 110, '黄沙河桥', '2016-11-12', '2016-11-12 12:30:58', 0, 0, NULL, NULL, '2016-11-12 12:30:58', '东莞市常平镇12某单位test', 112, 46, '2021-10-26 18:33:42', 0, NULL, NULL, NULL, NULL),
	(6, 110, '黄沙河桥', '2017-08-15', '2017-08-15 09:32:12', 0, 0, NULL, NULL, '2017-08-15 09:32:12', '东莞市常平镇12某单位test', 112, 46, '2021-10-26 18:33:42', 0, NULL, NULL, NULL, NULL),
	(7, 110, '黄沙河桥', '2016-10-06', '2016-10-06 14:12:27', 0, 0, NULL, NULL, '2016-10-06 14:12:27', '东莞市常平镇12某单位test', 112, 46, '2021-10-26 18:33:43', 0, NULL, NULL, NULL, NULL),
	(8, 110, '黄沙河桥', '2019-10-05', '2019-10-05 15:45:46', 0, 0, NULL, NULL, '2019-10-05 15:45:46', '东莞市常平镇12某单位test', 112, 46, '2021-10-26 18:33:44', 0, NULL, NULL, NULL, NULL),
	(9, 110, '黄沙河桥', '2017-03-11', '2017-03-11 20:38:05', 0, 0, NULL, NULL, '2017-03-11 20:38:05', '东莞市常平镇12某单位test', 112, 46, '2021-10-26 18:33:44', 0, NULL, NULL, NULL, NULL),
	(10, 110, '黄沙河桥', '2021-05-22', '2021-05-22 17:10:19', 0, 0, NULL, NULL, '2021-05-22 17:10:19', '东莞市常平镇12某单位test', 112, 46, '2021-10-26 18:33:45', 0, NULL, NULL, NULL, NULL);
/*!40000 ALTER TABLE `bge_manual_monitor` ENABLE KEYS */;

-- 导出  表 gdbs_dev.bge_manual_monitor_dict 结构
CREATE TABLE IF NOT EXISTS `bge_manual_monitor_dict` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `type_name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '类型名',
  `cloumn_name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '参数列名',
  `unit` varchar(10) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '单位，比如:mm,℃',
  `is_show` int(1) NOT NULL DEFAULT '1' COMMENT '是否启用, 1启用 ，0不启用',
  `remark` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '备注, 冗余字段',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='人工监测，测点类型字典';

-- 正在导出表  gdbs_dev.bge_manual_monitor_dict 的数据：13 rows
/*!40000 ALTER TABLE `bge_manual_monitor_dict` DISABLE KEYS */;
INSERT INTO `bge_manual_monitor_dict` (`id`, `type_name`, `cloumn_name`, `unit`, `is_show`, `remark`) VALUES
	(1, '沉降量', 'drop_down', 'mm', 1, NULL),
	(2, '温度', 'temperature', '℃', 1, NULL),
	(3, '裂缝宽度', 'crack_width', 'mm', 1, NULL),
	(4, '位移', 'distance', 'mm', 1, NULL),
	(5, '应变', 'reactivity', 'με', 1, NULL),
	(6, '倾角XS', 'angle_x', '°', 1, NULL),
	(7, '倾角YS', 'angle_y', '°', 1, NULL),
	(8, '索力', 'cable_force', 'kN', 1, NULL),
	(9, '平均风速', 'wind_speed', 'm/s', 1, NULL),
	(10, '风向', 'wind_direction', NULL, 1, NULL),
	(11, '湿度', 'wet', '%', 1, NULL),
	(12, '高度', 'height', 'mm', 1, NULL),
	(13, '倾覆', 'overturn', NULL, 1, NULL);
/*!40000 ALTER TABLE `bge_manual_monitor_dict` ENABLE KEYS */;

-- 导出  表 gdbs_dev.bge_manual_monitor_point_detail 结构
CREATE TABLE IF NOT EXISTS `bge_manual_monitor_point_detail` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `point_name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '测点名称, 比如：墩-10A',
  `drop_down` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '沉降量',
  `temperature` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '温度',
  `crack_width` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '裂缝宽度',
  `distance` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '位移',
  `reactivity` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '应变 ',
  `angle_x` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '倾角XS',
  `angle_y` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '倾角YS',
  `cable_force` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '索力',
  `wind_speed` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '平均风速',
  `wind_direction` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '风向',
  `wet` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '湿度',
  `height` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '高度',
  `overturn` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '倾覆',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `ver_name` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '版本名称',
  `ver_id` int(11) DEFAULT NULL COMMENT 'bge_manual_monitor主表id，版本id',
  `object_name` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '对象名，比如:C匝道',
  `update_time` datetime DEFAULT NULL COMMENT '更新时间',
  `bge_id` int(11) DEFAULT NULL COMMENT '桥梁主表id',
  `create_userid` int(11) DEFAULT NULL COMMENT '创建人id',
  `update_userid` int(11) DEFAULT NULL COMMENT '更新人id',
  `delete_userid` int(11) DEFAULT NULL COMMENT '删除人id',
  `is_deleted` int(1) NOT NULL DEFAULT '0' COMMENT '是否删除 1是，0否',
  PRIMARY KEY (`id`),
  KEY `ver_id` (`ver_id`),
  KEY `bge_id` (`bge_id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='桥梁监测-->人工监测 测点版本数据详情表';

-- 正在导出表  gdbs_dev.bge_manual_monitor_point_detail 的数据：0 rows
/*!40000 ALTER TABLE `bge_manual_monitor_point_detail` DISABLE KEYS */;
INSERT INTO `bge_manual_monitor_point_detail` (`id`, `point_name`, `drop_down`, `temperature`, `crack_width`, `distance`, `reactivity`, `angle_x`, `angle_y`, `cable_force`, `wind_speed`, `wind_direction`, `wet`, `height`, `overturn`, `create_time`, `ver_name`, `ver_id`, `object_name`, `update_time`, `bge_id`, `create_userid`, `update_userid`, `delete_userid`, `is_deleted`) VALUES
	(1, '墩-10C', NULL, NULL, NULL, '15', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2021-05-22 15:49:50', '2021-05-22', 10, 'A匝道', NULL, 110, 46, NULL, NULL, 0),
	(2, '墩-11C', NULL, NULL, NULL, '12', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2021-05-22 15:49:50', '2021-05-22', 10, 'A匝道', NULL, 110, 46, NULL, NULL, 0),
	(3, '墩-12C', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '20', NULL, NULL, NULL, NULL, NULL, '2021-05-22 15:49:50', '2021-05-22', 10, 'B匝道', NULL, 110, 46, NULL, NULL, 0),
	(4, '墩-13C', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '13', NULL, NULL, NULL, NULL, NULL, '2021-05-22 15:49:50', '2021-05-22', 10, 'B匝道', NULL, 110, 46, NULL, NULL, 0),
	(5, '墩-14C', NULL, NULL, NULL, '23', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2021-05-22 15:49:50', '2021-05-22', 10, 'C匝道', NULL, 110, 46, NULL, NULL, 0),
	(6, '墩-15C', NULL, NULL, NULL, '32', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2021-05-22 15:49:50', '2021-05-22', 10, 'C匝道', NULL, 110, 46, NULL, NULL, 0),
	(7, '墩-12C', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '22', NULL, NULL, NULL, NULL, NULL, '2021-05-22 15:49:50', '2021-05-22', 10, 'C匝道', NULL, 110, 46, NULL, NULL, 0),
	(8, '墩-11C', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '31', NULL, NULL, NULL, NULL, NULL, '2021-05-22 15:49:50', '2021-05-22', 10, 'C匝道', NULL, 110, 46, NULL, NULL, 0),
	(9, '墩-09B', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '15', '2021-05-22 15:49:50', '2021-05-22', 10, 'C匝道', NULL, 110, 46, NULL, NULL, 0),
	(10, '墩-06A', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '8', '2021-05-22 15:49:50', '2021-05-22', 10, 'C匝道', NULL, 110, 46, NULL, NULL, 0);
/*!40000 ALTER TABLE `bge_manual_monitor_point_detail` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
