CREATE TABLE `imagingdevice` (
  `ImagingDeviceNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `ComputerName` varchar(255) NOT NULL,
  `DeviceType` tinyint(4) NOT NULL,
  `TwainName` varchar(255) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `ShowTwainUI` tinyint(4) NOT NULL,
  PRIMARY KEY (`ImagingDeviceNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
