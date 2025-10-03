CREATE TABLE `signalod` (
  `SignalNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DateViewing` date NOT NULL DEFAULT '0001-01-01',
  `SigDateTime` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `FKey` bigint(20) NOT NULL,
  `FKeyType` varchar(255) NOT NULL,
  `IType` tinyint(4) NOT NULL,
  `RemoteRole` tinyint(4) NOT NULL,
  `MsgValue` text NOT NULL,
  PRIMARY KEY (`SignalNum`),
  KEY `indexSigDateTime` (`SigDateTime`),
  KEY `FKey` (`FKey`),
  KEY `IType` (`IType`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
