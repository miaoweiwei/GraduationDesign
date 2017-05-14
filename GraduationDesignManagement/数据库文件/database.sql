/*
Navicat MySQL Data Transfer

Source Server         : 我的服务器123.206.216.30
Source Server Version : 50553
Source Host           : 123.206.216.30:3306
Source Database       : database

Target Server Type    : MYSQL
Target Server Version : 50553
File Encoding         : 65001

Date: 2017-05-14 17:00:04
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for department_table
-- ----------------------------
DROP TABLE IF EXISTS `department_table`;
CREATE TABLE `department_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `departmentname` varchar(255) DEFAULT NULL,
  `class` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of department_table
-- ----------------------------
INSERT INTO `department_table` VALUES ('1', '计算机科学与技术', '13计科A1');
INSERT INTO `department_table` VALUES ('2', '计算机科学与技术', '13计科A2');
INSERT INTO `department_table` VALUES ('3', '计算机科学与技术', '13计科C1');
INSERT INTO `department_table` VALUES ('4', '网络工程', '13网络A1');
INSERT INTO `department_table` VALUES ('5', '网络工程', '13网络A2');
INSERT INTO `department_table` VALUES ('6', '软件工程', '13软工A1');
INSERT INTO `department_table` VALUES ('7', '软件工程', '13软工A2');
INSERT INTO `department_table` VALUES ('8', '数字媒体', '13数媒A1');
INSERT INTO `department_table` VALUES ('9', '数字媒体', '13数媒A2');
INSERT INTO `department_table` VALUES ('10', '自动化', '13自动A1');
INSERT INTO `department_table` VALUES ('11', '自动化', '13自动A2');

-- ----------------------------
-- Table structure for file_table
-- ----------------------------
DROP TABLE IF EXISTS `file_table`;
CREATE TABLE `file_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `filecode` varchar(255) DEFAULT NULL,
  `filename` varchar(255) DEFAULT NULL,
  `uploadtime` varchar(255) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  `downloadtime` int(255) DEFAULT '0',
  `size` varchar(255) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of file_table
-- ----------------------------
INSERT INTO `file_table` VALUES ('1', 'dfgwergaergfa', '1645784814-毕业设计(论文)题目.xlsx', '1493565419', '陈老师', '14', '11815 ');
INSERT INTO `file_table` VALUES ('2', 'asfaesrdtgaergergdsrtfhwrthqwregqervaserbg', '1493565419-毕业设计课题.zip', '1493561435', '李老师', '7', '106666');
INSERT INTO `file_table` VALUES ('11', 'b4e8fd21a228404c92a3a2668e35903c', '1494644831-毕业设计答辩分组2017.xlsx', '1494644831', '陈林', '1', '42338');
INSERT INTO `file_table` VALUES ('12', '79aaab71ef624e54b7bdedb86d5e1bda', '1494747849-基于qt的仓库管理系统.doc', '1494747849', '程老师', '0', '673280');

-- ----------------------------
-- Table structure for graduationdesign_table
-- ----------------------------
DROP TABLE IF EXISTS `graduationdesign_table`;
CREATE TABLE `graduationdesign_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `projectcode` varchar(255) DEFAULT NULL,
  `teacherid` varchar(255) DEFAULT NULL,
  `studentid` varchar(255) DEFAULT NULL,
  `pleateacherid` varchar(255) DEFAULT NULL,
  `beginscore` int(3) DEFAULT '0',
  `middlescore` int(3) DEFAULT '0',
  `endscore` int(3) DEFAULT '0',
  `begincomment` longtext,
  `middlecomment` longtext,
  `endcomment` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of graduationdesign_table
-- ----------------------------
INSERT INTO `graduationdesign_table` VALUES ('5', 'D9F8EC0D659D4AB59C9E385CF6E7B871', '2017001', '20134830275', '2017002', '87', '78', '75', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('6', '00000000000000000000000000000000', '2017001', '20134832527', '2017012', '25', '42', '75', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('8', 'A95D9E2C985047839A406CF61A650484', '2017001', '20134832535', '2017006', '89', '80', '98', '挺好', '', '');
INSERT INTO `graduationdesign_table` VALUES ('9', '42399de7e794446da25ebe174bd3dbf2', '2017007', '20124830311', '2017003', '86', '45', '86', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('10', 'c3ab42c581064205b5e182866ea28b4a', '2017007', '20134830695', '2017004', '96', '86', '86', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('11', '846f16ba5f674a5091761f145fe891f3', '2017002', '20134831605', '2017007', '35', '42', '75', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('12', 'f5100d88775741da99bc9f408b987f91', '2017007', '20134832455', '2017001', '90', '75', '85', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('13', '43946ae2e71d40258a3ced00ddd8636f', '2017001', '20124830062', '2017006', '90', '0', '75', '', null, '');
INSERT INTO `graduationdesign_table` VALUES ('14', '641e3ccc926040728dd88879dcc0d140', '2017002', '20134832484', '2017003', '75', '52', '63', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('15', 'eb6ec140096349478a4817959274c4f7', '2017002', '20134831487', '2017004', '30', '56', '46', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('16', '5117a7c0392943efad17485e56178edf', '2017002', '20134830119', '2017001', '86', '43', '42', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('17', '567e140bf467464ba40c93e7e6219265', '2017007', '20134833976', '2017002', '78', '78', '84', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('18', '2bedcbd3272341498609bdfdaadc3bab', '2017007', '20134833885', '2017012', '85', '75', '45', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('19', '7863ec09463b4d2182fc63a49ee06e5f', '2017002', '20124832860', '2017007', '42', '56', '75', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('20', '2341ba67c1314dc096581df553f0e22e', '2017006', '20134830717', '2017001', '98', '85', '86', '', '', '');
INSERT INTO `graduationdesign_table` VALUES ('21', 'bb717c6557f84eb9ab3b9ab289b0796c', '2017006', '20134831197', '2017002', '78', '53', '75', '', '', '');

-- ----------------------------
-- Table structure for graduationfile_table
-- ----------------------------
DROP TABLE IF EXISTS `graduationfile_table`;
CREATE TABLE `graduationfile_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `filecode` varchar(255) DEFAULT NULL,
  `filename` varchar(255) DEFAULT NULL,
  `uploadtime` varchar(255) DEFAULT NULL,
  `datetype` varchar(255) DEFAULT NULL,
  `studentid` varchar(255) DEFAULT NULL,
  `projectcode` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of graduationfile_table
-- ----------------------------
INSERT INTO `graduationfile_table` VALUES ('1', 'aefwaef', '1494140168-ExcelUDFTest.zip', '1494140168', 'BeginReply', '20134832535', 'A95D9E2C985047839A406CF61A650484');
INSERT INTO `graduationfile_table` VALUES ('2', '56tu56w', '1494140168-图像处理.zip', '1494140169', 'MiddleReply', '20134832535', 'A95D9E2C985047839A406CF61A650484');
INSERT INTO `graduationfile_table` VALUES ('3', 'a23wtrq3', '1494140168-Tetris.zip', '1494140165', 'EndReply', '20134832535', 'A95D9E2C985047839A406CF61A650484');
INSERT INTO `graduationfile_table` VALUES ('4', '6c1f9dacfc0640eeb4f1b6ec4c5420e9', '1494157577-毕业设计课题.zip', '1494140165', 'BeginReply', '20134832535', 'A95D9E2C985047839A406CF61A650484');
INSERT INTO `graduationfile_table` VALUES ('5', '3774f16e007944f6ae4bed419177ec93', '1494157744-图像处理.zip', '1494140145', 'EndReply', '20134832535', 'A95D9E2C985047839A406CF61A650484');
INSERT INTO `graduationfile_table` VALUES ('6', 'ff937f09365d490f9dcde991931c26e7', '1494158023-开题报告&任务书_苗卫伟.docx', '1494158023', 'EndReply', '20134832535', 'A95D9E2C985047839A406CF61A650484');
INSERT INTO `graduationfile_table` VALUES ('7', '33322fb0d4ba4181b9baa1daa2813d7c', '1494336744-51CTO下载-C#界面皮肤源码（带大量皮肤素材）.rar', '1494336744', 'BeginReply', '20134832455', 'f5100d88775741da99bc9f408b987f91');
INSERT INTO `graduationfile_table` VALUES ('8', '58aeb5bc055541478f4cbd6f88135283', '1494337147-RabbitMQ in Action.pdf', '1494337147', 'MiddleReply', '20134832455', 'f5100d88775741da99bc9f408b987f91');
INSERT INTO `graduationfile_table` VALUES ('9', '824000efd73a47c894a96b96270a8d69', '1494743883-工作簿1.xlsx', '1494743883', 'BeginReply', '20134833885', '2bedcbd3272341498609bdfdaadc3bab');
INSERT INTO `graduationfile_table` VALUES ('10', 'f434efa133e745ef9086e81bd7523c69', '1494743896-GDMAddInInstaller.msi', '1494743896', 'EndReply', '20134833885', '2bedcbd3272341498609bdfdaadc3bab');

-- ----------------------------
-- Table structure for project_table
-- ----------------------------
DROP TABLE IF EXISTS `project_table`;
CREATE TABLE `project_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `projectname` varchar(255) DEFAULT NULL,
  `introduce` varchar(255) DEFAULT NULL,
  `teacherid` varchar(255) DEFAULT NULL,
  `projectcode` varchar(255) DEFAULT NULL,
  `state` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of project_table
-- ----------------------------
INSERT INTO `project_table` VALUES ('1', '安卓游戏开发', '就是开发一个安卓游戏', '2017001', 'A95D9E2C985047839A406CF61A650484', '1');
INSERT INTO `project_table` VALUES ('2', 'C#游戏开发', '就是一个C#版的游戏呗', '2017001', 'D9F8EC0D659D4AB59C9E385CF6E7B871', '1');
INSERT INTO `project_table` VALUES ('8', '测速器的设计与实现', '设计一个测速器', '2017001', '00000000000000000000000000000000', '1');
INSERT INTO `project_table` VALUES ('9', '转速期的设计', '设计一款转速器', '2017001', '43946ae2e71d40258a3ced00ddd8636f', '1');
INSERT INTO `project_table` VALUES ('12', '基于Android的校园点餐外卖APP设计与实现', '基于Android的校园点餐外卖APP设计与实现App', '2017002', '641e3ccc926040728dd88879dcc0d140', '1');
INSERT INTO `project_table` VALUES ('13', '基于Android的母婴二手货交易APP设计与实现', '', '2017002', 'eb6ec140096349478a4817959274c4f7', '1');
INSERT INTO `project_table` VALUES ('14', '基于Android的医院预约挂号APP设计与实现', '', '2017002', '5117a7c0392943efad17485e56178edf', '1');
INSERT INTO `project_table` VALUES ('15', '五子棋手机小游戏的设计与实现', '一个很厉害的游戏', '2017002', '846f16ba5f674a5091761f145fe891f3', '1');
INSERT INTO `project_table` VALUES ('16', '扫雷手机小游戏的设计与实现', '扫雷手机小游戏的设计与实现', '2017002', '7863ec09463b4d2182fc63a49ee06e5f', '1');
INSERT INTO `project_table` VALUES ('17', '单片机电机正反转和堵转控制', '单片机电机正反转和堵转控制', '2017007', 'f5100d88775741da99bc9f408b987f91', '1');
INSERT INTO `project_table` VALUES ('18', '单片机时间逻辑控制', '单片机时间逻辑控制', '2017007', '2bedcbd3272341498609bdfdaadc3bab', '1');
INSERT INTO `project_table` VALUES ('19', '基于modbus的单片机通信', '基于modbus的单片机通信', '2017007', '567e140bf467464ba40c93e7e6219265', '1');
INSERT INTO `project_table` VALUES ('20', '电梯监控控制盒', '电梯监控控制盒', '2017007', 'c3ab42c581064205b5e182866ea28b4a', '1');
INSERT INTO `project_table` VALUES ('21', '单片机气体检测装置', '单片机气体检测装置', '2017007', '42399de7e794446da25ebe174bd3dbf2', '1');
INSERT INTO `project_table` VALUES ('22', '智能小车', '设计并制作一个智能小车', '2017006', 'bb717c6557f84eb9ab3b9ab289b0796c', '1');
INSERT INTO `project_table` VALUES ('23', '安卓提前预报小程序', '设计并制作安卓版的天气预报程序', '2017006', '2341ba67c1314dc096581df553f0e22e', '1');

-- ----------------------------
-- Table structure for schedule_table
-- ----------------------------
DROP TABLE IF EXISTS `schedule_table`;
CREATE TABLE `schedule_table` (
  `datetype` varchar(255) NOT NULL,
  `begindate` varchar(255) DEFAULT NULL,
  `enddate` varchar(255) DEFAULT NULL,
  `matter` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of schedule_table
-- ----------------------------
INSERT INTO `schedule_table` VALUES ('BeginReply', '2016-11-10', '2016-11-30', '向学生介绍课题，布置毕业设计（论文）任务');
INSERT INTO `schedule_table` VALUES ('BeginReply', '2016-12-01', '2016-12-15', '确认毕业设计任务，以及相应的系统功能模块');
INSERT INTO `schedule_table` VALUES ('BeginReply', '2016-12-01', '2017-01-10', '写开题报告，进行开题答辩，拟定解决毕业设计的关键问题');
INSERT INTO `schedule_table` VALUES ('BeginReply', '2016-12-11', '2017-02-21', '进行需求分析，基本确定技术路线与目标，熟悉开发工具与平台，外文翻译资料；提交开题报告');
INSERT INTO `schedule_table` VALUES ('MiddleReply', '2017-02-22', '2017-04-13', '进行各模块的开发，调式；并接受中期检查');
INSERT INTO `schedule_table` VALUES ('MiddleReply', '2017-02-14', '2017-04-27', '进行论文的撰写');
INSERT INTO `schedule_table` VALUES ('EndReply', '2017-04-28', '2017-05-11', '交论文、英译中等文档，提供指导教师审阅，并按要求修改论文');
INSERT INTO `schedule_table` VALUES ('EndReply', '2017-05-12', '2017-05-22', '毕业设计（论文）评阅、审查');
INSERT INTO `schedule_table` VALUES ('EndReply', '2017-05-23', '2017-05-23', '毕业答辩');

-- ----------------------------
-- Table structure for student_table
-- ----------------------------
DROP TABLE IF EXISTS `student_table`;
CREATE TABLE `student_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `studentid` varchar(255) DEFAULT NULL,
  `studentname` varchar(255) DEFAULT NULL,
  `class` varchar(255) DEFAULT NULL,
  `stupassword` varchar(255) DEFAULT NULL,
  `iscan` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=227 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of student_table
-- ----------------------------
INSERT INTO `student_table` VALUES ('1', '20134833494', '邵青', '13计科A1', '20134833494', '1');
INSERT INTO `student_table` VALUES ('2', '20134830576', '谢英甜', '13计科A1', '20134830576', '1');
INSERT INTO `student_table` VALUES ('3', '20134834047', '王静', '13计科A1', '20134834047', '1');
INSERT INTO `student_table` VALUES ('4', '20134830645', '熊啸', '13计科A1', '20134830645', '1');
INSERT INTO `student_table` VALUES ('5', '20134831876', '吴陈燕', '13计科A1', '20134831876', '1');
INSERT INTO `student_table` VALUES ('6', '20134830624', '王新月', '13计科A1', '20134830624', '1');
INSERT INTO `student_table` VALUES ('7', '20134834226', '唐金鑫', '13计科A1', '20134834226', '1');
INSERT INTO `student_table` VALUES ('8', '20134832706', '徐玉玲', '13计科A1', '20134832706', '1');
INSERT INTO `student_table` VALUES ('9', '20134831599', '张陪', '13计科A1', '20134831599', '1');
INSERT INTO `student_table` VALUES ('10', '20134830959', '刘冬民', '13计科A1', '20134830959', '1');
INSERT INTO `student_table` VALUES ('11', '20134830236', '江燕', '13计科A1', '20134830236', '1');
INSERT INTO `student_table` VALUES ('12', '20134830249', '俞龙', '13计科A1', '20134830249', '1');
INSERT INTO `student_table` VALUES ('13', '20134832115', '朱成龙', '13计科A1', '20134832115', '1');
INSERT INTO `student_table` VALUES ('14', '20134833957', '李宁', '13计科A1', '20134833957', '1');
INSERT INTO `student_table` VALUES ('15', '20134833024', '黎彩', '13计科A1', '20134833024', '1');
INSERT INTO `student_table` VALUES ('16', '20134831209', '闫琢文', '13计科A1', '20134831209', '1');
INSERT INTO `student_table` VALUES ('17', '20134831634', '邓姝婷', '13计科A1', '20134831634', '1');
INSERT INTO `student_table` VALUES ('18', '20134831086', '杨建汇', '13计科A1', '20134831086', '1');
INSERT INTO `student_table` VALUES ('19', '20134830076', '蒋昊宏', '13计科A1', '20134830076', '1');
INSERT INTO `student_table` VALUES ('20', '20134831326', '胡宏强', '13计科A1', '20134831326', '1');
INSERT INTO `student_table` VALUES ('21', '20134832349', '顾佳宇', '13计科A1', '20134832349', '1');
INSERT INTO `student_table` VALUES ('22', '20134830687', '朱书坤', '13计科A1', '20134830687', '1');
INSERT INTO `student_table` VALUES ('23', '20134830985', '魏秋俊', '13计科A1', '20134830985', '1');
INSERT INTO `student_table` VALUES ('24', '20134830464', '熊逸隽', '13计科A1', '20134830464', '1');
INSERT INTO `student_table` VALUES ('25', '20134831735', '吴思超', '13计科A1', '20134831735', '1');
INSERT INTO `student_table` VALUES ('26', '20134833056', '唐刘', '13计科A1', '20134833056', '1');
INSERT INTO `student_table` VALUES ('27', '20134832979', '韩玉', '13计科A1', '20134832979', '1');
INSERT INTO `student_table` VALUES ('28', '20134833699', '伍文君', '13计科A1', '20134833699', '1');
INSERT INTO `student_table` VALUES ('29', '20134833199', '朱诗年', '13计科A1', '20134833199', '1');
INSERT INTO `student_table` VALUES ('30', '20134830039', '韦刘强', '13计科A1', '20134830039', '1');
INSERT INTO `student_table` VALUES ('31', '20134832399', '刘明明', '13计科A1', '20134832399', '1');
INSERT INTO `student_table` VALUES ('32', '20134830225', '刘邦梁', '13计科A1', '20134830225', '1');
INSERT INTO `student_table` VALUES ('33', '20134831894', '秦俊', '13计科A1', '20134831894', '1');
INSERT INTO `student_table` VALUES ('34', '20134832256', '徐斌', '13计科A1', '20134832256', '1');
INSERT INTO `student_table` VALUES ('35', '20134831746', '凌涛', '13计科A1', '20134831746', '1');
INSERT INTO `student_table` VALUES ('36', '20134830355', '李天瑞', '13计科A1', '20134830355', '1');
INSERT INTO `student_table` VALUES ('37', '20114831957', '沈春刚', '13计科A1', '20114831957', '1');
INSERT INTO `student_table` VALUES ('38', '20114831019', '徐来彬', '13计科A1', '20114831019', '1');
INSERT INTO `student_table` VALUES ('39', '20134830275', '包瑞锋', '13计科A2', '20134830275', '1');
INSERT INTO `student_table` VALUES ('40', '20134832527', '蔡辉', '13计科A2', '20134832527', '1');
INSERT INTO `student_table` VALUES ('41', '20134830695', '陈星', '13计科A2', '20134830695', '1');
INSERT INTO `student_table` VALUES ('42', '20124830062', '陈喆', '13计科A2', '20124830062', '1');
INSERT INTO `student_table` VALUES ('43', '20134832484', '成坤', '13计科A2', '20134832484', '1');
INSERT INTO `student_table` VALUES ('44', '20134831605', '窦书明', '13计科A2', '20134831605', '1');
INSERT INTO `student_table` VALUES ('45', '20134831487', '范志鹏', '13计科A2', '20134831487', '1');
INSERT INTO `student_table` VALUES ('46', '20134830119', '甘金富', '13计科A2', '20134830119', '1');
INSERT INTO `student_table` VALUES ('47', '20134833976', '雷竣麟', '13计科A2', '20134833976', '1');
INSERT INTO `student_table` VALUES ('48', '20134833885', '李发勇', '13计科A2', '20134833885', '1');
INSERT INTO `student_table` VALUES ('49', '20124832860', '李虎', '13计科A2', '20124832860', '1');
INSERT INTO `student_table` VALUES ('50', '20134832455', '林发宁', '13计科A2', '20134832455', '1');
INSERT INTO `student_table` VALUES ('51', '20134831714', '林旋', '13计科A2', '20134831714', '1');
INSERT INTO `student_table` VALUES ('52', '20134833359', '林振宇', '13计科A2', '20134833359', '1');
INSERT INTO `student_table` VALUES ('53', '20134833444', '刘建春', '13计科A2', '20134833444', '1');
INSERT INTO `student_table` VALUES ('54', '20134830089', '马永龙', '13计科A2', '20134830089', '1');
INSERT INTO `student_table` VALUES ('55', '20134832535', '苗卫伟', '13计科A2', '20134832535', '1');
INSERT INTO `student_table` VALUES ('56', '20134833255', '木拉提·买买提', '13计科A2', '20134833255', '1');
INSERT INTO `student_table` VALUES ('57', '20134831679', '秋欢欢', '13计科A2', '20134831679', '1');
INSERT INTO `student_table` VALUES ('58', '20124830311', '任建民', '13计科A2', '20124830311', '1');
INSERT INTO `student_table` VALUES ('59', '20134831857', '赛皮丁.艾则孜', '13计科A2', '20134831857', '1');
INSERT INTO `student_table` VALUES ('60', '20134830717', '苏艺君', '13计科A2', '20134830717', '1');
INSERT INTO `student_table` VALUES ('61', '20134831197', '孙倩', '13计科A2', '20134831197', '1');
INSERT INTO `student_table` VALUES ('62', '20134831147', '王达霄', '13计科A2', '20134831147', '1');
INSERT INTO `student_table` VALUES ('63', '20124833761', '王杰', '13计科A2', '20124833761', '1');
INSERT INTO `student_table` VALUES ('64', '20134830145', '王奇', '13计科A2', '20134830145', '1');
INSERT INTO `student_table` VALUES ('65', '20124833900', '王志文', '13计科A2', '20124833900', '1');
INSERT INTO `student_table` VALUES ('66', '20134833407', '韦正列', '13计科A2', '20134833407', '1');
INSERT INTO `student_table` VALUES ('67', '20124834033', '吴宇翔', '13计科A2', '20124834033', '1');
INSERT INTO `student_table` VALUES ('68', '20124832428', '谢健', '13计科A2', '20124832428', '1');
INSERT INTO `student_table` VALUES ('69', '20134831445', '邢冰', '13计科A2', '20134831445', '1');
INSERT INTO `student_table` VALUES ('70', '20134833537', '徐文清', '13计科A2', '20134833537', '1');
INSERT INTO `student_table` VALUES ('71', '20114831247', '许学金', '13计科A2', '20114831247', '1');
INSERT INTO `student_table` VALUES ('72', '20114830966', '杨百威', '13计科A2', '20114830966', '1');
INSERT INTO `student_table` VALUES ('73', '20134831365', '杨冬琼', '13计科A2', '20134831365', '1');
INSERT INTO `student_table` VALUES ('74', '20134830927', '杨磊', '13计科A2', '20134830927', '1');
INSERT INTO `student_table` VALUES ('75', '20134833364', '杨鹏强', '13计科A2', '20134833364', '1');
INSERT INTO `student_table` VALUES ('76', '20134833186', '杨涛', '13计科A2', '20134833186', '1');
INSERT INTO `student_table` VALUES ('77', '20134834196', '叶尔夏提', '13计科A2', '20134834196', '1');
INSERT INTO `student_table` VALUES ('78', '20134833939', '张帅威', '13计科A2', '20134833939', '1');
INSERT INTO `student_table` VALUES ('79', '20134832224', '张易成', '13计科A2', '20134832224', '1');
INSERT INTO `student_table` VALUES ('80', '20134831616', '张泽玉', '13计科A2', '20134831616', '1');
INSERT INTO `student_table` VALUES ('81', '20124831951', '张子昂', '13计科A2', '20124831951', '1');
INSERT INTO `student_table` VALUES ('82', '20134833545', '赵永明', '13计科A2', '20134833545', '1');
INSERT INTO `student_table` VALUES ('83', '20134831184', '钟莹', '13计科A2', '20134831184', '1');
INSERT INTO `student_table` VALUES ('84', '20134833377', '周铁军', '13计科A2', '20134833377', '1');
INSERT INTO `student_table` VALUES ('85', '20134831666', '左津菽', '13计科A2', '20134831666', '1');
INSERT INTO `student_table` VALUES ('86', '20114831415', '余祥福', '13计科A2', '20114831415', '1');
INSERT INTO `student_table` VALUES ('87', '20134830565', '罗菲菲', '13计科C1', '20134830565', null);
INSERT INTO `student_table` VALUES ('88', '20134830195', '吴俊杨', '13计科C1', '20134830195', null);
INSERT INTO `student_table` VALUES ('89', '20134830366', '王洁菲', '13计科C1', '20134830366', null);
INSERT INTO `student_table` VALUES ('90', '20134830935', '陈通通', '13计科C1', '20134830935', null);
INSERT INTO `student_table` VALUES ('91', '20134830964', '许富强', '13计科C1', '20134830964', null);
INSERT INTO `student_table` VALUES ('92', '20134833649', '许恺琳', '13计科C1', '20134833649', null);
INSERT INTO `student_table` VALUES ('93', '20134833439', '张福敦', '13计科C1', '20134833439', null);
INSERT INTO `student_table` VALUES ('94', '20134832514', '孟令熙', '13计科C1', '20134832514', null);
INSERT INTO `student_table` VALUES ('95', '20134833595', '杨凯', '13计科C1', '20134833595', null);
INSERT INTO `student_table` VALUES ('96', '20134831075', '郑忠', '13计科C1', '20134831075', null);
INSERT INTO `student_table` VALUES ('97', '20134833604', '龚逸航', '13计科C1', '20134833604', null);
INSERT INTO `student_table` VALUES ('98', '20134832867', '陈星星', '13计科C1', '20134832867', null);
INSERT INTO `student_table` VALUES ('99', '20134831987', '覃凌云', '13计科C1', '20134831987', null);
INSERT INTO `student_table` VALUES ('100', '20134832096', '秦微东', '13计科C1', '20134832096', null);
INSERT INTO `student_table` VALUES ('101', '20134832694', '陆卫豪', '13计科C1', '20134832694', null);
INSERT INTO `student_table` VALUES ('102', '20134832795', '杨少雄', '13计科C1', '20134832795', null);
INSERT INTO `student_table` VALUES ('103', '20134830805', '赵丹妮', '13计科C1', '20134830805', null);
INSERT INTO `student_table` VALUES ('104', '20134831307', '赵启旸', '13计科C1', '20134831307', null);
INSERT INTO `student_table` VALUES ('105', '20134832317', '麦尔旦·麦热瓦依提', '13计科C1', '20134832317', null);
INSERT INTO `student_table` VALUES ('106', '20134831235', '田超凡', '13计科C1', '20134831235', null);
INSERT INTO `student_table` VALUES ('107', '20134831655', '汪兆丰', '13计科C1', '20134831655', null);
INSERT INTO `student_table` VALUES ('108', '20134832825', '何昊', '13计科C1', '20134832825', null);
INSERT INTO `student_table` VALUES ('109', '20134832237', '金晓杰', '13计科C1', '20134832237', null);
INSERT INTO `student_table` VALUES ('110', '20134832724', '黄鸣杰', '13计科C1', '20134832724', null);
INSERT INTO `student_table` VALUES ('111', '20134832737', '肖靖功', '13计科C1', '20134832737', null);
INSERT INTO `student_table` VALUES ('112', '20134833125', '王衡', '13计科C1', '20134833125', null);
INSERT INTO `student_table` VALUES ('113', '20134833167', '裘润杰', '13计科C1', '20134833167', null);
INSERT INTO `student_table` VALUES ('114', '20134832304', '叶政德', '13计科C1', '20134832304', null);
INSERT INTO `student_table` VALUES ('115', '20134833556', '浦岱睿', '13计科C1', '20134833556', null);
INSERT INTO `student_table` VALUES ('116', '20134830786', '方子川', '13计科C1', '20134830786', null);
INSERT INTO `student_table` VALUES ('117', '20153410620', '徐思昊', '13网络A2', '20153410620', null);
INSERT INTO `student_table` VALUES ('118', '20134831554', '梁正洪', '13网络A2', '20134831554', null);
INSERT INTO `student_table` VALUES ('119', '20134830946', '周晴甜', '13网络A2', '20134830946', null);
INSERT INTO `student_table` VALUES ('120', '20134833346', '张伟强', '13网络A2', '20134833346', null);
INSERT INTO `student_table` VALUES ('121', '20134831129', '邓帅', '13网络A2', '20134831129', null);
INSERT INTO `student_table` VALUES ('122', '20153410608', '唐天鹤', '13网络A2', '20153410608', null);
INSERT INTO `student_table` VALUES ('123', '20134832194', '孙成', '13网络A2', '20134832194', null);
INSERT INTO `student_table` VALUES ('124', '20124833488', '薛之源', '13网络A2', '20124833488', null);
INSERT INTO `student_table` VALUES ('125', '20134832585', '王圆圆', '13网络A2', '20134832585', null);
INSERT INTO `student_table` VALUES ('126', '20153410613', '徐迎芳', '13网络A2', '20153410613', null);
INSERT INTO `student_table` VALUES ('127', '20134833809', '李志伟', '13网络A2', '20134833809', null);
INSERT INTO `student_table` VALUES ('128', '20134832219', '王玉龙', '13网络A2', '20134832219', null);
INSERT INTO `student_table` VALUES ('129', '20134833729', '邱世轩', '13网络A2', '20134833729', null);
INSERT INTO `student_table` VALUES ('130', '20134831969', '黄宁', '13网络A2', '20134831969', null);
INSERT INTO `student_table` VALUES ('131', '20134831517', '韦桂赟', '13网络A2', '20134831517', null);
INSERT INTO `student_table` VALUES ('132', '20134834239', '王欢', '13网络A2', '20134834239', null);
INSERT INTO `student_table` VALUES ('133', '20134834177', '蒋凯', '13网络A2', '20134834177', null);
INSERT INTO `student_table` VALUES ('134', '20134833747', '许骁一', '13网络A2', '20134833747', null);
INSERT INTO `student_table` VALUES ('135', '20114834075', '王路遥', '13网络A2', '20114834075', null);
INSERT INTO `student_table` VALUES ('136', '20134832626', '吴宏程', '13网络A2', '20134832626', null);
INSERT INTO `student_table` VALUES ('137', '20134832429', '黄凯杰', '13网络A2', '20134832429', null);
INSERT INTO `student_table` VALUES ('138', '20134830749', '高虎军', '13网络A2', '20134830749', null);
INSERT INTO `student_table` VALUES ('139', '20134830829', '沈越', '13网络A2', '20134830829', null);
INSERT INTO `student_table` VALUES ('140', '20153410632', '邱文蕾', '13网络A2', '20153410632', null);
INSERT INTO `student_table` VALUES ('141', '20134830816', '谢政硕', '13网络A2', '20134830816', null);
INSERT INTO `student_table` VALUES ('142', '20124823146', '陈梓欣', '13网络A2', '20124823146', null);
INSERT INTO `student_table` VALUES ('143', '20134831054', '黄培', '13网络A2', '20134831054', null);
INSERT INTO `student_table` VALUES ('144', '20124833391', '冯英豪', '13网络A2', '20124833391', null);
INSERT INTO `student_table` VALUES ('145', '20134830799', '袁逸飞', '13网络A2', '20134830799', null);
INSERT INTO `student_table` VALUES ('146', '20124834271', '罗天振', '13网络A2', '20124834271', null);
INSERT INTO `student_table` VALUES ('147', '20134831549', '张亚秋', '13网络A2', '20134831549', null);
INSERT INTO `student_table` VALUES ('148', '20134832745', '吕俊杰', '13网络A2', '20134832745', null);
INSERT INTO `student_table` VALUES ('149', '20134822291', '周贤军', '13自动A1', '20134822291', null);
INSERT INTO `student_table` VALUES ('150', '20134822708', '王瑞', '13自动A1', '20134822708', null);
INSERT INTO `student_table` VALUES ('151', '20134822548', '张春宇', '13自动A1', '20134822548', null);
INSERT INTO `student_table` VALUES ('152', '20134822480', '陈帅', '13自动A1', '20134822480', null);
INSERT INTO `student_table` VALUES ('153', '20134822763', '陈晓瑜', '13自动A1', '20134822763', null);
INSERT INTO `student_table` VALUES ('154', '20134822602', '尤戈', '13自动A1', '20134822602', null);
INSERT INTO `student_table` VALUES ('155', '20134822741', '范双雪', '13自动A1', '20134822741', null);
INSERT INTO `student_table` VALUES ('156', '20134860132', '边小敏', '13自动A1', '20134860132', null);
INSERT INTO `student_table` VALUES ('157', '20134822942', '杨天', '13自动A1', '20134822942', null);
INSERT INTO `student_table` VALUES ('158', '20134822581', '朱婉云', '13自动A1', '20134822581', null);
INSERT INTO `student_table` VALUES ('159', '20134823452', '刘超', '13自动A1', '20134823452', null);
INSERT INTO `student_table` VALUES ('160', '20134822720', '王方', '13自动A1', '20134822720', null);
INSERT INTO `student_table` VALUES ('161', '20134822713', '尤兴发', '13自动A1', '20134822713', null);
INSERT INTO `student_table` VALUES ('162', '20134822843', '张晓婕', '13自动A1', '20134822843', null);
INSERT INTO `student_table` VALUES ('163', '20134822270', '晁云鹏', '13自动A1', '20134822270', null);
INSERT INTO `student_table` VALUES ('164', '20134822758', '李盼盼', '13自动A1', '20134822758', null);
INSERT INTO `student_table` VALUES ('165', '20134822678', '邢文宇', '13自动A1', '20134822678', null);
INSERT INTO `student_table` VALUES ('166', '20134822503', '崔毅峰', '13自动A1', '20134822503', null);
INSERT INTO `student_table` VALUES ('167', '20134822862', '母昌迪', '13自动A1', '20134822862', null);
INSERT INTO `student_table` VALUES ('168', '20134822782', '张志豪', '13自动A1', '20134822782', null);
INSERT INTO `student_table` VALUES ('169', '20134822628', '张乐乐', '13自动A1', '20134822628', null);
INSERT INTO `student_table` VALUES ('170', '20134822652', '常开厚', '13自动A1', '20134822652', null);
INSERT INTO `student_table` VALUES ('171', '20134822683', '徐向荣', '13自动A1', '20134822683', null);
INSERT INTO `student_table` VALUES ('172', '20114821570', '特日格乐', '13自动A1', '20114821570', null);
INSERT INTO `student_table` VALUES ('173', '20134822690', '冀策', '13自动A1', '20134822690', null);
INSERT INTO `student_table` VALUES ('174', '20134822901', '吴威', '13自动A1', '20134822901', null);
INSERT INTO `student_table` VALUES ('175', '20134822871', '陈金科', '13自动A1', '20134822871', null);
INSERT INTO `student_table` VALUES ('176', '20134823402', '刘昌东', '13自动A1', '20134823402', null);
INSERT INTO `student_table` VALUES ('177', '20134822572', '桑达杰', '13自动A1', '20134822572', null);
INSERT INTO `student_table` VALUES ('178', '20114821860', '邓仕银', '13自动A1', '20114821860', null);
INSERT INTO `student_table` VALUES ('179', '20134822611', '王璐', '13自动A1', '20134822611', null);
INSERT INTO `student_table` VALUES ('180', '20134822770', '陈亚鹏', '13自动A1', '20134822770', null);
INSERT INTO `student_table` VALUES ('181', '20134822640', '朱思旭', '13自动A1', '20134822640', null);
INSERT INTO `student_table` VALUES ('182', '20134822732', '吴昊', '13自动A1', '20134822732', null);
INSERT INTO `student_table` VALUES ('183', '20134822522', '宋哲文', '13自动A1', '20134822522', null);
INSERT INTO `student_table` VALUES ('184', '20134822821', '赵国清', '13自动A1', '20134822821', null);
INSERT INTO `student_table` VALUES ('185', '20124823097', '刘胡宾', '13自动A1', '20124823097', null);
INSERT INTO `student_table` VALUES ('186', '20134822850', '黄振', '13自动A1', '20134822850', null);
INSERT INTO `student_table` VALUES ('187', '20124823215', '张志强', '13自动A1', '20124823215', null);
INSERT INTO `student_table` VALUES ('188', '20134823150', '李雨虹', '13自动A2', '20134823150', null);
INSERT INTO `student_table` VALUES ('189', '20134823070', '魏晶晶', '13自动A2', '20134823070', null);
INSERT INTO `student_table` VALUES ('190', '20153410641', '陈伟', '13自动A2', '20153410641', null);
INSERT INTO `student_table` VALUES ('191', '20153410663', '杜赟', '13自动A2', '20153410663', null);
INSERT INTO `student_table` VALUES ('192', '20134823348', '高晋生', '13自动A2', '20134823348', null);
INSERT INTO `student_table` VALUES ('193', '20134823162', '盛松松', '13自动A2', '20134823162', null);
INSERT INTO `student_table` VALUES ('194', '20153410658', '邢旭东', '13自动A2', '20153410658', null);
INSERT INTO `student_table` VALUES ('195', '20153410670', '钱志军', '13自动A2', '20153410670', null);
INSERT INTO `student_table` VALUES ('196', '20134823171', '吴雪纯', '13自动A2', '20134823171', null);
INSERT INTO `student_table` VALUES ('197', '20134823483', '廖波', '13自动A2', '20134823483', null);
INSERT INTO `student_table` VALUES ('198', '20134823121', '暴亚南', '13自动A2', '20134823121', null);
INSERT INTO `student_table` VALUES ('199', '20134823020', '陆静', '13自动A2', '20134823020', null);
INSERT INTO `student_table` VALUES ('200', '20134823508', '徐一竣', '13自动A2', '20134823508', null);
INSERT INTO `student_table` VALUES ('201', '20134823242', '曾琪', '13自动A2', '20134823242', null);
INSERT INTO `student_table` VALUES ('202', '20134823520', '赵天航', '13自动A2', '20134823520', null);
INSERT INTO `student_table` VALUES ('203', '20134823372', '王旭东', '13自动A2', '20134823372', null);
INSERT INTO `student_table` VALUES ('204', '20134823063', '陈晓星', '13自动A2', '20134823063', null);
INSERT INTO `student_table` VALUES ('205', '20134822888', '陈曦', '13自动A2', '20134822888', null);
INSERT INTO `student_table` VALUES ('206', '20134822893', '李雅', '13自动A2', '20134822893', null);
INSERT INTO `student_table` VALUES ('207', '20134823310', '李政开', '13自动A2', '20134823310', null);
INSERT INTO `student_table` VALUES ('208', '20134823353', '刘静', '13自动A2', '20134823353', null);
INSERT INTO `student_table` VALUES ('209', '20134823251', '王黎琦', '13自动A2', '20134823251', null);
INSERT INTO `student_table` VALUES ('210', '20134822968', '赵宁波', '13自动A2', '20134822968', null);
INSERT INTO `student_table` VALUES ('211', '20134823322', '曹俊麟', '13自动A2', '20134823322', null);
INSERT INTO `student_table` VALUES ('212', '20134822951', '许成好', '13自动A2', '20134822951', null);
INSERT INTO `student_table` VALUES ('213', '20134823478', '杨伟', '13自动A2', '20134823478', null);
INSERT INTO `student_table` VALUES ('214', '20124823794', '彭宗楠', '13自动A2', '20124823794', null);
INSERT INTO `student_table` VALUES ('215', '20134823411', '袁超', '13自动A2', '20134823411', null);
INSERT INTO `student_table` VALUES ('216', '20114822648', '马晨峰', '13自动A2', '20114822648', null);
INSERT INTO `student_table` VALUES ('217', '20134823273', '孙智璐', '13自动A2', '20134823273', null);
INSERT INTO `student_table` VALUES ('218', '20134823303', '张国虎', '13自动A2', '20134823303', null);
INSERT INTO `student_table` VALUES ('219', '20134823041', '吴松礼', '13自动A2', '20134823041', null);
INSERT INTO `student_table` VALUES ('220', '20134823360', '李新龙', '13自动A2', '20134823360', null);
INSERT INTO `student_table` VALUES ('221', '20134823428', '蔡济俊', '13自动A2', '20134823428', null);
INSERT INTO `student_table` VALUES ('222', '20134823032', '徐能园', '13自动A2', '20134823032', null);
INSERT INTO `student_table` VALUES ('223', '20134823331', '魏传超', '13自动A2', '20134823331', null);
INSERT INTO `student_table` VALUES ('224', '20134823230', '涂文兵', '13自动A2', '20134823230', null);
INSERT INTO `student_table` VALUES ('225', '20134823193', '王诗博', '13自动A2', '20134823193', null);
INSERT INTO `student_table` VALUES ('226', '20124823856', '张靖浩', '13自动A2', '20124823856', null);

-- ----------------------------
-- Table structure for teacher_table
-- ----------------------------
DROP TABLE IF EXISTS `teacher_table`;
CREATE TABLE `teacher_table` (
  `id` int(15) NOT NULL AUTO_INCREMENT,
  `teacherid` varchar(25) DEFAULT NULL,
  `teachername` varchar(25) DEFAULT NULL,
  `position` varchar(25) DEFAULT NULL,
  `department` varchar(30) DEFAULT NULL,
  `teapassword` varchar(25) DEFAULT NULL,
  `iscan` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of teacher_table
-- ----------------------------
INSERT INTO `teacher_table` VALUES ('1', '2017001', '曹老师', '普通教师', '计算机科学与技术', '2017001', '1');
INSERT INTO `teacher_table` VALUES ('2', '2017002', '林老师', '普通教师', '计算机科学与技术', '2017002', '1');
INSERT INTO `teacher_table` VALUES ('3', '2017003', '崔老师', '普通教师', '计算机科学与技术', '2017003', '1');
INSERT INTO `teacher_table` VALUES ('4', '2017004', '黄老师', '普通教师', '计算机科学与技术', '2017004', '1');
INSERT INTO `teacher_table` VALUES ('5', '2017005', '李老师', '普通教师', '计算机科学与技术', '2017005', null);
INSERT INTO `teacher_table` VALUES ('6', '2017006', '程老师', '系主任', '计算机科学与技术', '2017006', '1');
INSERT INTO `teacher_table` VALUES ('7', '2017007', '刘老师', '普通教师', '计算机科学与技术', '2017007', '1');
INSERT INTO `teacher_table` VALUES ('8', '2017008', '杨老师', '普通教师', '计算机科学与技术', '2017008', null);
INSERT INTO `teacher_table` VALUES ('9', '2017009', '刘老师', '普通教师', '软件工程', '2017009', null);
INSERT INTO `teacher_table` VALUES ('10', '2017010', '王老师', '普通教师', '数字媒体', '2017010', null);
INSERT INTO `teacher_table` VALUES ('11', '2017011', '李老师', '普通教师', '网络工程', '2017011', '1');
INSERT INTO `teacher_table` VALUES ('12', '2017012', '陈老师', '普通教师', '计算机科学与技术', '2017012', '1');
INSERT INTO `teacher_table` VALUES ('13', '2017013', '李老师', '系主任', '软件工程', '2017013', '0');
INSERT INTO `teacher_table` VALUES ('14', '2017014', '孙老师', '普通教师', '软件工程', '2017014', '0');
INSERT INTO `teacher_table` VALUES ('15', '2017015', '赵老师', '系主任', '网络工程', '2017015', '1');
