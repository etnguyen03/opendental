CREATE TABLE `ehrtrigger` (
  `EhrTriggerNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `ProblemSnomedList` text NOT NULL,
  `ProblemIcd9List` text NOT NULL,
  `ProblemIcd10List` text NOT NULL,
  `ProblemDefNumList` text NOT NULL,
  `MedicationNumList` text NOT NULL,
  `RxCuiList` text NOT NULL,
  `CvxList` text NOT NULL,
  `AllergyDefNumList` text NOT NULL,
  `DemographicsList` text NOT NULL,
  `LabLoincList` text NOT NULL,
  `VitalLoincList` text NOT NULL,
  `Instructions` text NOT NULL,
  `Bibliography` text NOT NULL,
  `Cardinality` tinyint(4) NOT NULL,
  PRIMARY KEY (`EhrTriggerNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
