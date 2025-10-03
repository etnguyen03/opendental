CREATE TABLE `ehrmeasure` (
  `EhrMeasureNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `MeasureType` tinyint(4) NOT NULL,
  `Numerator` smallint(6) NOT NULL,
  `Denominator` smallint(6) NOT NULL,
  PRIMARY KEY (`EhrMeasureNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
