CREATE TABLE `deletedobject` (
  `DeletedObjectNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ObjectNum` bigint(20) NOT NULL,
  `ObjectType` int(11) NOT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`DeletedObjectNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
