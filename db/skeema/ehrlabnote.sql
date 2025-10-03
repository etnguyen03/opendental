CREATE TABLE `ehrlabnote` (
  `EhrLabNoteNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EhrLabNum` bigint(20) NOT NULL,
  `EhrLabResultNum` bigint(20) NOT NULL,
  `Comments` text NOT NULL,
  PRIMARY KEY (`EhrLabNoteNum`),
  KEY `EhrLabNum` (`EhrLabNum`),
  KEY `EhrLabResultNum` (`EhrLabResultNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
