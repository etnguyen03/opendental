-- Seed ProcedureCodes table with 38 standard CDT codes
INSERT INTO "ProcedureCodes" ("ProcedureCodeId", "Code", "Description", "AbbrDesc", "DefaultFee", "Category", "IsActive", "CreatedDate", "ModifiedDate")
VALUES
-- Diagnostic
(1, 'D0120', 'Periodic oral evaluation - established patient', 'Periodic Exam', 75.00, 'Diagnostic', true, NOW(), NULL),
(2, 'D0140', 'Limited oral evaluation - problem focused', 'Limited Exam', 65.00, 'Diagnostic', true, NOW(), NULL),
(3, 'D0150', 'Comprehensive oral evaluation - new or established patient', 'Comp Exam', 95.00, 'Diagnostic', true, NOW(), NULL),
(4, 'D0210', 'Intraoral - complete series of radiographic images', 'FMX', 125.00, 'Diagnostic', true, NOW(), NULL),
(5, 'D0220', 'Intraoral - periapical first radiographic image', 'PA', 35.00, 'Diagnostic', true, NOW(), NULL),
(6, 'D0230', 'Intraoral - periapical each additional radiographic image', 'PA Add''l', 25.00, 'Diagnostic', true, NOW(), NULL),
(7, 'D0270', 'Bitewing - single radiographic image', 'BW Single', 30.00, 'Diagnostic', true, NOW(), NULL),
(8, 'D0274', 'Bitewings - four radiographic images', '4 BWs', 65.00, 'Diagnostic', true, NOW(), NULL),
(9, 'D0330', 'Panoramic radiographic image', 'Pano', 95.00, 'Diagnostic', true, NOW(), NULL),

-- Preventive
(10, 'D1110', 'Prophylaxis - adult', 'Adult Prophy', 95.00, 'Preventive', true, NOW(), NULL),
(11, 'D1120', 'Prophylaxis - child', 'Child Prophy', 75.00, 'Preventive', true, NOW(), NULL),
(12, 'D1206', 'Topical application of fluoride varnish', 'Fluoride Varnish', 35.00, 'Preventive', true, NOW(), NULL),
(13, 'D1208', 'Topical application of fluoride - excluding varnish', 'Fluoride Treatment', 30.00, 'Preventive', true, NOW(), NULL),
(14, 'D1351', 'Sealant - per tooth', 'Sealant', 55.00, 'Preventive', true, NOW(), NULL),

-- Restorative
(15, 'D2140', 'Amalgam - one surface, primary or permanent', 'Amalgam 1 Surf', 140.00, 'Restorative', true, NOW(), NULL),
(16, 'D2150', 'Amalgam - two surfaces, primary or permanent', 'Amalgam 2 Surf', 175.00, 'Restorative', true, NOW(), NULL),
(17, 'D2160', 'Amalgam - three surfaces, primary or permanent', 'Amalgam 3 Surf', 210.00, 'Restorative', true, NOW(), NULL),
(18, 'D2330', 'Resin-based composite - one surface, anterior', 'Comp 1 Surf Ant', 155.00, 'Restorative', true, NOW(), NULL),
(19, 'D2331', 'Resin-based composite - two surfaces, anterior', 'Comp 2 Surf Ant', 185.00, 'Restorative', true, NOW(), NULL),
(20, 'D2332', 'Resin-based composite - three surfaces, anterior', 'Comp 3 Surf Ant', 220.00, 'Restorative', true, NOW(), NULL),
(21, 'D2391', 'Resin-based composite - one surface, posterior', 'Comp 1 Surf Post', 165.00, 'Restorative', true, NOW(), NULL),
(22, 'D2392', 'Resin-based composite - two surfaces, posterior', 'Comp 2 Surf Post', 195.00, 'Restorative', true, NOW(), NULL),
(23, 'D2393', 'Resin-based composite - three surfaces, posterior', 'Comp 3 Surf Post', 235.00, 'Restorative', true, NOW(), NULL),

-- Endodontics
(24, 'D3310', 'Endodontic therapy, anterior tooth', 'RCT Anterior', 750.00, 'Endodontics', true, NOW(), NULL),
(25, 'D3320', 'Endodontic therapy, premolar tooth', 'RCT Premolar', 900.00, 'Endodontics', true, NOW(), NULL),
(26, 'D3330', 'Endodontic therapy, molar tooth', 'RCT Molar', 1150.00, 'Endodontics', true, NOW(), NULL),

-- Periodontics
(27, 'D4341', 'Periodontal scaling and root planing - four or more teeth per quadrant', 'SRP per Quad', 240.00, 'Periodontics', true, NOW(), NULL),
(28, 'D4342', 'Periodontal scaling and root planing - one to three teeth per quadrant', 'SRP 1-3 Teeth', 140.00, 'Periodontics', true, NOW(), NULL),

-- Prosthodontics - Removable
(29, 'D5110', 'Complete denture - maxillary', 'Upper Denture', 1500.00, 'Prosthodontics', true, NOW(), NULL),
(30, 'D5120', 'Complete denture - mandibular', 'Lower Denture', 1500.00, 'Prosthodontics', true, NOW(), NULL),
(31, 'D5213', 'Partial denture - maxillary, resin base', 'Upper Partial', 1200.00, 'Prosthodontics', true, NOW(), NULL),
(32, 'D5214', 'Partial denture - mandibular, resin base', 'Lower Partial', 1200.00, 'Prosthodontics', true, NOW(), NULL),

-- Prosthodontics - Fixed
(33, 'D6240', 'Pontic - porcelain fused to high noble metal', 'PFM Pontic', 950.00, 'Prosthodontics', true, NOW(), NULL),
(34, 'D6750', 'Crown - porcelain fused to high noble metal', 'PFM Crown', 1100.00, 'Prosthodontics', true, NOW(), NULL),
(35, 'D6010', 'Surgical placement of endosteal implant', 'Implant Placement', 2000.00, 'Prosthodontics', true, NOW(), NULL),

-- Oral Surgery
(36, 'D7140', 'Extraction, erupted tooth or exposed root', 'Simple Extraction', 150.00, 'Oral Surgery', true, NOW(), NULL),
(37, 'D7210', 'Extraction, erupted tooth requiring removal of bone and/or sectioning of tooth', 'Surgical Extraction', 250.00, 'Oral Surgery', true, NOW(), NULL),
(38, 'D7240', 'Removal of impacted tooth - completely bony', 'Impacted Tooth', 400.00, 'Oral Surgery', true, NOW(), NULL)
ON CONFLICT ("ProcedureCodeId") DO NOTHING;
