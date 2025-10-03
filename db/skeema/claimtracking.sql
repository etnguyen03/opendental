CREATE TABLE `claimtracking` (
  `ClaimTrackingNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClaimNum` bigint(20) NOT NULL,
  `TrackingType` varchar(255) NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  `DateTimeEntry` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Note` text NOT NULL,
  `TrackingDefNum` bigint(20) NOT NULL,
  `TrackingErrorDefNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ClaimTrackingNum`),
  KEY `ClaimNum` (`ClaimNum`),
  KEY `UserNum` (`UserNum`),
  KEY `TrackingDefNum` (`TrackingDefNum`),
  KEY `TrackingErrorDefNum` (`TrackingErrorDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
