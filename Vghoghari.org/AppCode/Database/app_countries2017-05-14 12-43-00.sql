USE vghoghariorg;

CREATE TABLE `app_countries` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` int(11) NOT NULL,
  `shortname` varchar(3) NOT NULL,
  `name` varchar(200) NOT NULL,
  `value` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=247 DEFAULT CHARSET=utf8;


insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (1,1,'AF','Afghanistan','Afghanistan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (2,2,'AL','Albania','Albania');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (3,3,'DZ','Algeria','Algeria');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (4,4,'AS','American Samoa','American Samoa');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (5,5,'AD','Andorra','Andorra');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (6,6,'AO','Angola','Angola');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (7,7,'AI','Anguilla','Anguilla');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (8,8,'AQ','Antarctica','Antarctica');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (9,9,'AG','Antigua And Barbuda','Antigua And Barbuda');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (10,10,'AR','Argentina','Argentina');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (11,11,'AM','Armenia','Armenia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (12,12,'AW','Aruba','Aruba');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (13,13,'AU','Australia','Australia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (14,14,'AT','Austria','Austria');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (15,15,'AZ','Azerbaijan','Azerbaijan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (16,16,'BS','Bahamas The','Bahamas The');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (17,17,'BH','Bahrain','Bahrain');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (18,18,'BD','Bangladesh','Bangladesh');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (19,19,'BB','Barbados','Barbados');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (20,20,'BY','Belarus','Belarus');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (21,21,'BE','Belgium','Belgium');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (22,22,'BZ','Belize','Belize');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (23,23,'BJ','Benin','Benin');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (24,24,'BM','Bermuda','Bermuda');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (25,25,'BT','Bhutan','Bhutan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (26,26,'BO','Bolivia','Bolivia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (27,27,'BA','Bosnia and Herzegovina','Bosnia and Herzegovina');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (28,28,'BW','Botswana','Botswana');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (29,29,'BV','Bouvet Island','Bouvet Island');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (30,30,'BR','Brazil','Brazil');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (31,31,'IO','British Indian Ocean Territory','British Indian Ocean Territory');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (32,32,'BN','Brunei','Brunei');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (33,33,'BG','Bulgaria','Bulgaria');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (34,34,'BF','Burkina Faso','Burkina Faso');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (35,35,'BI','Burundi','Burundi');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (36,36,'KH','Cambodia','Cambodia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (37,37,'CM','Cameroon','Cameroon');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (38,38,'CA','Canada','Canada');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (39,39,'CV','Cape Verde','Cape Verde');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (40,40,'KY','Cayman Islands','Cayman Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (41,41,'CF','Central African Republic','Central African Republic');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (42,42,'TD','Chad','Chad');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (43,43,'CL','Chile','Chile');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (44,44,'CN','China','China');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (45,45,'CX','Christmas Island','Christmas Island');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (46,46,'CC','Cocos (Keeling) Islands','Cocos (Keeling) Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (47,47,'CO','Colombia','Colombia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (48,48,'KM','Comoros','Comoros');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (49,49,'CG','Congo','Congo');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (50,50,'CD','Congo The Democratic Republic Of The','Congo The Democratic Republic Of The');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (51,51,'CK','Cook Islands','Cook Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (52,52,'CR','Costa Rica','Costa Rica');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (53,53,'CI','Cote D''Ivoire (Ivory Coast)','Cote D''Ivoire (Ivory Coast)');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (54,54,'HR','Croatia (Hrvatska)','Croatia (Hrvatska)');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (55,55,'CU','Cuba','Cuba');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (56,56,'CY','Cyprus','Cyprus');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (57,57,'CZ','Czech Republic','Czech Republic');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (58,58,'DK','Denmark','Denmark');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (59,59,'DJ','Djibouti','Djibouti');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (60,60,'DM','Dominica','Dominica');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (61,61,'DO','Dominican Republic','Dominican Republic');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (62,62,'TP','East Timor','East Timor');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (63,63,'EC','Ecuador','Ecuador');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (64,64,'EG','Egypt','Egypt');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (65,65,'SV','El Salvador','El Salvador');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (66,66,'GQ','Equatorial Guinea','Equatorial Guinea');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (67,67,'ER','Eritrea','Eritrea');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (68,68,'EE','Estonia','Estonia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (69,69,'ET','Ethiopia','Ethiopia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (70,70,'XA','External Territories of Australia','External Territories of Australia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (71,71,'FK','Falkland Islands','Falkland Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (72,72,'FO','Faroe Islands','Faroe Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (73,73,'FJ','Fiji Islands','Fiji Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (74,74,'FI','Finland','Finland');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (75,75,'FR','France','France');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (76,76,'GF','French Guiana','French Guiana');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (77,77,'PF','French Polynesia','French Polynesia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (78,78,'TF','French Southern Territories','French Southern Territories');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (79,79,'GA','Gabon','Gabon');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (80,80,'GM','Gambia The','Gambia The');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (81,81,'GE','Georgia','Georgia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (82,82,'DE','Germany','Germany');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (83,83,'GH','Ghana','Ghana');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (84,84,'GI','Gibraltar','Gibraltar');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (85,85,'GR','Greece','Greece');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (86,86,'GL','Greenland','Greenland');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (87,87,'GD','Grenada','Grenada');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (88,88,'GP','Guadeloupe','Guadeloupe');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (89,89,'GU','Guam','Guam');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (90,90,'GT','Guatemala','Guatemala');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (91,91,'XU','Guernsey and Alderney','Guernsey and Alderney');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (92,92,'GN','Guinea','Guinea');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (93,93,'GW','Guinea-Bissau','Guinea-Bissau');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (94,94,'GY','Guyana','Guyana');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (95,95,'HT','Haiti','Haiti');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (96,96,'HM','Heard and McDonald Islands','Heard and McDonald Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (97,97,'HN','Honduras','Honduras');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (98,98,'HK','Hong Kong S.A.R.','Hong Kong S.A.R.');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (99,99,'HU','Hungary','Hungary');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (100,100,'IS','Iceland','Iceland');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (101,101,'IN','India','India');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (102,102,'ID','Indonesia','Indonesia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (103,103,'IR','Iran','Iran');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (104,104,'IQ','Iraq','Iraq');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (105,105,'IE','Ireland','Ireland');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (106,106,'IL','Israel','Israel');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (107,107,'IT','Italy','Italy');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (108,108,'JM','Jamaica','Jamaica');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (109,109,'JP','Japan','Japan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (110,110,'XJ','Jersey','Jersey');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (111,111,'JO','Jordan','Jordan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (112,112,'KZ','Kazakhstan','Kazakhstan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (113,113,'KE','Kenya','Kenya');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (114,114,'KI','Kiribati','Kiribati');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (115,115,'KP','Korea North','Korea North');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (116,116,'KR','Korea South','Korea South');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (117,117,'KW','Kuwait','Kuwait');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (118,118,'KG','Kyrgyzstan','Kyrgyzstan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (119,119,'LA','Laos','Laos');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (120,120,'LV','Latvia','Latvia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (121,121,'LB','Lebanon','Lebanon');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (122,122,'LS','Lesotho','Lesotho');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (123,123,'LR','Liberia','Liberia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (124,124,'LY','Libya','Libya');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (125,125,'LI','Liechtenstein','Liechtenstein');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (126,126,'LT','Lithuania','Lithuania');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (127,127,'LU','Luxembourg','Luxembourg');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (128,128,'MO','Macau S.A.R.','Macau S.A.R.');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (129,129,'MK','Macedonia','Macedonia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (130,130,'MG','Madagascar','Madagascar');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (131,131,'MW','Malawi','Malawi');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (132,132,'MY','Malaysia','Malaysia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (133,133,'MV','Maldives','Maldives');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (134,134,'ML','Mali','Mali');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (135,135,'MT','Malta','Malta');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (136,136,'XM','Man (Isle of)','Man (Isle of)');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (137,137,'MH','Marshall Islands','Marshall Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (138,138,'MQ','Martinique','Martinique');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (139,139,'MR','Mauritania','Mauritania');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (140,140,'MU','Mauritius','Mauritius');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (141,141,'YT','Mayotte','Mayotte');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (142,142,'MX','Mexico','Mexico');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (143,143,'FM','Micronesia','Micronesia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (144,144,'MD','Moldova','Moldova');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (145,145,'MC','Monaco','Monaco');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (146,146,'MN','Mongolia','Mongolia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (147,147,'MS','Montserrat','Montserrat');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (148,148,'MA','Morocco','Morocco');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (149,149,'MZ','Mozambique','Mozambique');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (150,150,'MM','Myanmar','Myanmar');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (151,151,'NA','Namibia','Namibia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (152,152,'NR','Nauru','Nauru');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (153,153,'NP','Nepal','Nepal');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (154,154,'AN','Netherlands Antilles','Netherlands Antilles');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (155,155,'NL','Netherlands The','Netherlands The');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (156,156,'NC','New Caledonia','New Caledonia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (157,157,'NZ','New Zealand','New Zealand');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (158,158,'NI','Nicaragua','Nicaragua');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (159,159,'NE','Niger','Niger');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (160,160,'NG','Nigeria','Nigeria');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (161,161,'NU','Niue','Niue');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (162,162,'NF','Norfolk Island','Norfolk Island');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (163,163,'MP','Northern Mariana Islands','Northern Mariana Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (164,164,'NO','Norway','Norway');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (165,165,'OM','Oman','Oman');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (166,166,'PK','Pakistan','Pakistan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (167,167,'PW','Palau','Palau');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (168,168,'PS','Palestinian Territory Occupied','Palestinian Territory Occupied');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (169,169,'PA','Panama','Panama');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (170,170,'PG','Papua new Guinea','Papua new Guinea');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (171,171,'PY','Paraguay','Paraguay');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (172,172,'PE','Peru','Peru');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (173,173,'PH','Philippines','Philippines');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (174,174,'PN','Pitcairn Island','Pitcairn Island');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (175,175,'PL','Poland','Poland');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (176,176,'PT','Portugal','Portugal');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (177,177,'PR','Puerto Rico','Puerto Rico');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (178,178,'QA','Qatar','Qatar');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (179,179,'RE','Reunion','Reunion');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (180,180,'RO','Romania','Romania');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (181,181,'RU','Russia','Russia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (182,182,'RW','Rwanda','Rwanda');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (183,183,'SH','Saint Helena','Saint Helena');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (184,184,'KN','Saint Kitts And Nevis','Saint Kitts And Nevis');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (185,185,'LC','Saint Lucia','Saint Lucia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (186,186,'PM','Saint Pierre and Miquelon','Saint Pierre and Miquelon');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (187,187,'VC','Saint Vincent And The Grenadines','Saint Vincent And The Grenadines');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (188,188,'WS','Samoa','Samoa');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (189,189,'SM','San Marino','San Marino');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (190,190,'ST','Sao Tome and Principe','Sao Tome and Principe');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (191,191,'SA','Saudi Arabia','Saudi Arabia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (192,192,'SN','Senegal','Senegal');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (193,193,'RS','Serbia','Serbia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (194,194,'SC','Seychelles','Seychelles');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (195,195,'SL','Sierra Leone','Sierra Leone');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (196,196,'SG','Singapore','Singapore');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (197,197,'SK','Slovakia','Slovakia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (198,198,'SI','Slovenia','Slovenia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (199,199,'XG','Smaller Territories of the UK','Smaller Territories of the UK');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (200,200,'SB','Solomon Islands','Solomon Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (201,201,'SO','Somalia','Somalia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (202,202,'ZA','South Africa','South Africa');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (203,203,'GS','South Georgia','South Georgia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (204,204,'SS','South Sudan','South Sudan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (205,205,'ES','Spain','Spain');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (206,206,'LK','Sri Lanka','Sri Lanka');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (207,207,'SD','Sudan','Sudan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (208,208,'SR','Suriname','Suriname');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (209,209,'SJ','Svalbard And Jan Mayen Islands','Svalbard And Jan Mayen Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (210,210,'SZ','Swaziland','Swaziland');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (211,211,'SE','Sweden','Sweden');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (212,212,'CH','Switzerland','Switzerland');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (213,213,'SY','Syria','Syria');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (214,214,'TW','Taiwan','Taiwan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (215,215,'TJ','Tajikistan','Tajikistan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (216,216,'TZ','Tanzania','Tanzania');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (217,217,'TH','Thailand','Thailand');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (218,218,'TG','Togo','Togo');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (219,219,'TK','Tokelau','Tokelau');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (220,220,'TO','Tonga','Tonga');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (221,221,'TT','Trinidad And Tobago','Trinidad And Tobago');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (222,222,'TN','Tunisia','Tunisia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (223,223,'TR','Turkey','Turkey');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (224,224,'TM','Turkmenistan','Turkmenistan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (225,225,'TC','Turks And Caicos Islands','Turks And Caicos Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (226,226,'TV','Tuvalu','Tuvalu');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (227,227,'UG','Uganda','Uganda');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (228,228,'UA','Ukraine','Ukraine');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (229,229,'AE','United Arab Emirates','United Arab Emirates');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (230,230,'GB','United Kingdom','United Kingdom');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (231,231,'US','United States','United States');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (232,232,'UM','United States Minor Outlying Islands','United States Minor Outlying Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (233,233,'UY','Uruguay','Uruguay');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (234,234,'UZ','Uzbekistan','Uzbekistan');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (235,235,'VU','Vanuatu','Vanuatu');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (236,236,'VA','Vatican City State (Holy See)','Vatican City State (Holy See)');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (237,237,'VE','Venezuela','Venezuela');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (238,238,'VN','Vietnam','Vietnam');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (239,239,'VG','Virgin Islands (British)','Virgin Islands (British)');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (240,240,'VI','Virgin Islands (US)','Virgin Islands (US)');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (241,241,'WF','Wallis And Futuna Islands','Wallis And Futuna Islands');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (242,242,'EH','Western Sahara','Western Sahara');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (243,243,'YE','Yemen','Yemen');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (244,244,'YU','Yugoslavia','Yugoslavia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (245,245,'ZM','Zambia','Zambia');
insert into `app_countries`(`id`,`code`,`shortname`,`name`,`value`) values (246,246,'ZW','Zimbabwe','Zimbabwe');
