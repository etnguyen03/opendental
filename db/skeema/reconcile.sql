CREATE TABLE `reconcile` (
  `ReconcileNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `AccountNum` bigint(20) NOT NULL,
  `StartingBal` double NOT NULL DEFAULT 0,
  `EndingBal` double NOT NULL DEFAULT 0,
  `DateReconcile` date NOT NULL DEFAULT '0001-01-01',
  `IsLocked` tinyint(3) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`ReconcileNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
