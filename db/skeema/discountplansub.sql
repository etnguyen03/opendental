CREATE TABLE `discountplansub` (
  `DiscountSubNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DiscountPlanNum` bigint(20) NOT NULL,
  `PatNum` bigint(20) NOT NULL,
  `DateEffective` date NOT NULL DEFAULT '0001-01-01',
  `DateTerm` date NOT NULL DEFAULT '0001-01-01',
  `SubNote` text NOT NULL,
  PRIMARY KEY (`DiscountSubNum`),
  KEY `DiscountPlanNum` (`DiscountPlanNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
