USE AlatechMachines;

SET IDENTITY_INSERT [user] ON;
go
INSERT INTO [user] (id, username, [password], accessToken)
VALUES (1, 'joaomartinscoube', '$2b$10$QkRiwT3WpeOQGE.ESMABteP..tlP09Z34IHukcRMbysvdEaZjmvB6', 'bc766d8f6d37c03c4c88531a8c8c2076'), -- password: senai_701
       (2, 'robertosimonsen', '$2b$10$2ahSlVjJLQyMuFZMlKplYuf7MbQ8dzHxRxq6dBN6JSnx4YZExLgDi', '15740e007f96a9c8f67b868cd34c2f62'), -- password: senai_101
       (3, 'franciscomatarazzo', '$2b$10$rDCjycD2tpgFj87fEujKeeau0sAsZ4ITFJIxrUT90dTYXK5bL9ihG', 'cc1ae7810de5d6becc7ddbd7e4d9f0ac'); -- password: senai_107
SET IDENTITY_INSERT [user] OFF;

SET IDENTITY_INSERT brand ON;
go
INSERT INTO brand (id, [name])
VALUES (1, 'Intel'),
       (2, 'AMD'),
       (3, 'ASUS'),
       (4, 'Nvidia'),
       (5, 'Corsair'),
       (6, 'Kingston'),
       (7, 'HyperX'),
       (8, 'Gigabyte'),
       (9, 'ASRock'),
       (10, 'MSi'),
       (11, 'XPG'),
       (12, 'Samsung'),
       (13, 'WesternDigital'),
       (14, 'Seagate'),
       (15, 'EVGA'),
       (16, 'Galax'),
       (17, 'XFX'),
       (18, 'Sapphire'),
       (19, 'PowerColor');
SET IDENTITY_INSERT brand OFF;


SET IDENTITY_INSERT socketType ON;
go
INSERT INTO socketType (id, [name])
VALUES (1, 'AM4'),
       (2, 'LGA 1151'),
       (3, 'LGA 2066'),
       (4, 'TR4'),
       (5, 'sTRX4');
SET IDENTITY_INSERT socketType OFF;

SET IDENTITY_INSERT ramMemoryType ON;
go
INSERT INTO ramMemoryType (id, [name])
VALUES (1, 'DDR3'),
       (2, 'DDR4');
SET IDENTITY_INSERT ramMemoryType OFF;
       
SET IDENTITY_INSERT motherboard ON;
go
INSERT INTO motherboard (id, [name], imageUrl, brandId, socketTypeId, ramMemoryTypeId, ramMemorySlots, maxTdp, sataSlots, m2Slots, pciSlots)
VALUES (1, 'X299X Aorus Xtreme Waterforce', '1', 8, 3, 2, 8, 165, 8, 2, 3),
       (2, 'X570 AQUA', '2', 9, 1, 2, 4, 105, 8, 2, 3),
       (3, 'MEG X570 Godlike', '3', 10, 5, 2, 4, 100, 6, 3, 4),
       (4, 'X570 Aorus Xtreme', '4', 8, 5, 2, 4, 100, 6, 3, 3),
       (5, 'Z390 Aorus Xtreme', '5', 8, 2, 2, 4, 100, 6, 3, 3),
       (6, 'X399 Aorus Xtreme', '8', 8, 4, 2, 8, 250, 6, 3, 4),
       (7, 'ROG Strix TRX40-E Gaming', '10', 3, 5, 2, 8, 280, 8, 3, 3),
       (8, 'GA-H170-GAMING 3', '38', 8, 2, 1, 4, 120, 8, 2, 2),
       (9, 'GA-H170M-D3H', '39', 8, 2, 1, 4, 105, 8, 1, 2);
SET IDENTITY_INSERT motherboard OFF;
  
SET IDENTITY_INSERT processor ON;
go
INSERT INTO processor (id, [name], imageUrl, brandId, socketTypeId, cores, baseFrequency, maxFrequency, cacheMemory, tdp)
VALUES (1, 'i9-9980XE Skylake', '6', 1, 3, 18, 3000, 4400, 25344, 165),
       (2, 'Ryzen Threadripper 2990WX', '7', 2, 5, 32, 3000, 4200, 65536, 250),
       (3, 'Ryzen Threadripper 3960X', '9', 2, 5, 24, 3800, 4500, 131072, 280),
       (4, 'i9-7920X Skylake', '11', 1, 3, 12, 2900, 4200, 16896, 140),
       (5, 'i9-10920X Cascade Lake', '12', 1, 3, 12, 3500, 4600, 19712, 165),
       (6, ' i9-9900KS Coffee Lake Refresh', '42', 1, 2, 8, 4000, 5000, 16384, 127);
SET IDENTITY_INSERT processor OFF;
  
SET IDENTITY_INSERT ramMemory ON;
go
INSERT INTO ramMemory (id, [name], imageUrl, brandId, size, ramMemoryTypeId, frequency)
VALUES (1, 'HyperX Fury 32GB 3000MHz', '13', 7, 32768, 2, 3000),
       (2, 'HyperX Fury 32GB 2666MHz', '14', 7, 32768, 2, 2666),
       (3, 'HyperX Fury 32GB 2400MHz', '15', 7, 32768, 2, 2400),
       (4, 'Corsair Vengeance 8GB 1600Mhz', '16', 5, 8192, 1, 1600),
       (5, 'HyperX Fury 8GB 1600MHz', '17', 7, 8192, 1, 1600);
SET IDENTITY_INSERT ramMemory OFF;
  
SET IDENTITY_INSERT storageDevice ON;
go
INSERT INTO storageDevice (id, [name], imageUrl, brandId, storageDeviceType, size, storageDeviceInterface)
VALUES (1, 'XPG Gammix S50', '18', 11, 1, 2048, 1),
       (2, 'Corsair Force Series MP600', '19', 5, 1, 2048, 1),
       (3, 'Samsung 970 EVO Plus', '20', 12, 1, 1024, 1),
       (4, 'WD Purple Surveillance 3.5''', '21', 13, 0, 12288, 0),
       (5, 'Seagate BarraCuda Pro', '22', 14, 0, 10240, 0);
SET IDENTITY_INSERT storageDevice OFF;
  
SET IDENTITY_INSERT graphicCard ON;
go
INSERT INTO graphicCard (id, [name], imageUrl, brandId, memorySize, memoryType, minimumPowerSupply, supportMultiGpu)
VALUES (1, 'GeForce RTX 2070 Super XC Ultra + Overclocked', '23', 15, 8192, 1, 650, 0),
       (2, 'GeForce RTX 2080 Super HOF 10th Anniversary Edition Black Teclab', '24', 16, 8192, 1, 650, 1),
       (3, 'GeForce RTX 2080 Ti KINGPIN Gaming', '25', 15, 11264, 1, 650, 1),
       (4, 'Radeon Red Devil RX5700', '26', 19, 8192, 1, 650, 0),
       (5, 'Radeon RX 5700 XT Nitro+', '27', 18, 8192, 1, 600, 1),
       (6, 'GeForce GTX 1070 Gaming ACX 3.0', '41', 15, 8192, 0, 450, 1);
SET IDENTITY_INSERT graphicCard OFF;

SET IDENTITY_INSERT badge80Plus ON;
go
INSERT INTO badge80Plus (id, [name])
values (1, 'none'),
       (2, 'white'),
       (3, 'bronze'),
       (4, 'silver'),
       (5, 'gold'),
       (6, 'platinum'),
       (7, 'titanium');
SET IDENTITY_INSERT badge80Plus OFF;

SET IDENTITY_INSERT powerSupply ON;
go
INSERT INTO powerSupply (id, [name], imageUrl, brandId, potency, badge80PlusId)
VALUES (1, 'AX1200i', '28', 5, 1200, 6),
       (2, 'AX1000', '29', 5, 1000, 7),
       (3, 'HX750i', '30', 5, 750, 6),
       (4, 'RMx', '31', 5, 750, 5),
       (5, 'SF Series 450W', '32', 5, 450, 6);
SET IDENTITY_INSERT powerSupply OFF;

SET IDENTITY_INSERT machine ON;
go
INSERT INTO machine (id, [name], description, imageUrl, motherboardId, processorId, ramMemoryId, ramMemoryAmount, graphicCardId, graphicCardAmount, powerSupplyId)
VALUES (1, 'Infinity', 'The highest and best you could get from a gamer machine.', '33', 1, 1, 1, 4, 5, 2, 1),
       (2, 'Shine', 'Light gives a huge power to someone.', '35', 7, 2, 2, 2, 1, 1, 3),
       (3, 'Wave', 'The sequences and perfection of waves bring this machine all the power electrons carry.', '37', 3, 3, 1, 2, 3, 1, 2),
       (4, 'Cerberus', 'The unexpected will bring you a lot more than you expected.', '34', 4, 2, 3, 2, 4, 1, 4),
       (5, 'Iceberg', 'An ice-solid experience for your gaming days.', '36', 7, 2, 1, 4, 6, 2, 2),
       (6, 'Soft', 'The softer version that knows how to play hard.', '40', 9, 6, 5, 4, 6, 1, 5);
SET IDENTITY_INSERT machine OFF;

SET IDENTITY_INSERT machineHasStorageDevice ON;
go
INSERT INTO machineHasStorageDevice (id, machineId, storageDeviceId, amount)
VALUES (1, 1, 1, 1),
       (2, 1, 5, 1),
       (3, 2, 2, 1),
       (4, 3, 3, 1),
       (5, 3, 4, 1),
       (6, 4, 2, 1),
       (7, 5, 2, 1),
       (8, 6, 3, 1);
SET IDENTITY_INSERT machineHasStorageDevice OFF;