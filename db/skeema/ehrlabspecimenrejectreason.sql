CREATE TABLE `ehrlabspecimenrejectreason` (
  `EhrLabSpecimenRejectReasonNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EhrLabSpecimenNum` bigint(20) NOT NULL,
  `SpecimenRejectReasonID` varchar(255) NOT NULL,
  `SpecimenRejectReasonText` varchar(255) NOT NULL,
  `SpecimenRejectReasonCodeSystemName` varchar(255) NOT NULL,
  `SpecimenRejectReasonIDAlt` varchar(255) NOT NULL,
  `SpecimenRejectReasonTextAlt` varchar(255) NOT NULL,
  `SpecimenRejectReasonCodeSystemNameAlt` varchar(255) NOT NULL,
  `SpecimenRejectReasonTextOriginal` varchar(255) NOT NULL,
  PRIMARY KEY (`EhrLabSpecimenRejectReasonNum`),
  KEY `EhrLabSpecimenNum` (`EhrLabSpecimenNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
