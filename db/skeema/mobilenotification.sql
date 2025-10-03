CREATE TABLE `mobilenotification` (
  `MobileNotificationNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `NotificationType` tinyint(4) NOT NULL,
  `DeviceId` varchar(255) NOT NULL,
  `PrimaryKeys` text NOT NULL,
  `Tags` text NOT NULL,
  `DateTimeEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `DateTimeExpires` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `AppTarget` tinyint(4) NOT NULL,
  PRIMARY KEY (`MobileNotificationNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
