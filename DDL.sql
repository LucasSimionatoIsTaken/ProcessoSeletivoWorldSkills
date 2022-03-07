use master
go
drop database if exists AlatechMachines;
go
create database AlatechMachines;
go
use AlatechMachines;

create table [user] (
	id int primary key identity not null,
    username varchar(64) not null,
    [password] varchar(512) not null,
    accessToken varchar(512) not null,
    -- constraint primary key(id)
);

create table brand (
	id int primary key identity not null,
    [name] varchar(96) not null,
    -- constraint primary key(id)
);

create table socketType (
	id int primary key identity not null,
    [name] varchar(96) not null,
    -- constraint primary key(id)
);

create table ramMemoryType (
	id int primary key identity not null,
    [name] varchar(96) not null,
    -- constraint primary key(id)
);

create table motherboard (
	id int primary key identity not null,
    [name] varchar(96) not null,
    imageUrl varchar(512) not null,
    ramMemorySlots int not null,
    maxTdp int not null,
    sataSlots int not null,
    m2Slots int not null,
    pciSlots int not null,
    ramMemoryTypeId int foreign key references ramMemoryType(id) not null,
    socketTypeId int foreign key references socketType(id) not null,
    brandId int foreign key references brand(id) not null,
    -- constraint primary key(id)
);

create table processor (
	id int primary key identity not null,
    [name] varchar(96) not null,
    imageUrl varchar(512) not null,
    cores int not null,
    baseFrequency float not null,
    maxFrequency float not null,
    cacheMemory float not null,
    tdp int not null,
    socketTypeId int foreign key references socketType(id) not null,
    brandId int foreign key references brand(id) not null,
    -- constraint primary key(id)
);

create table ramMemory (
	id int primary key identity not null,
    [name] varchar(96) not null,
    imageUrl varchar(512) not null,
    size int not null,
    frequency float not null,
    ramMemoryTypeId int foreign key references ramMemoryType(id) not null,
    brandId int foreign key references brand(id) not null,
    -- constraint primary key(id)
);

create table storageDevice (
	id int primary key identity not null,
    [name] varchar(96) not null,
    imageUrl varchar(512) not null,
    storageDeviceType bit not null, -- 0 'hdd', 1 'ssd'
    size int not null,
    storageDeviceInterface bit not null, -- 0 'sata', 1 'm2')
    brandId int foreign key references brand(id) not null,
    -- constraint primary key(id)
);

create table graphicCard (
	id int primary key identity not null,
    [name] varchar(96) not null,
    imageUrl varchar(512) not null,
    memorySize int not null,
    memoryType bit not null, -- 0 'gddr5', 1 'gddr6'
    minimumPowerSupply int not null,
    supportMultiGpu bit not null,
    brandId int foreign key references brand(id) not null,
    -- constraint primary key(id)
);

create table badge80Plus(
	id int primary key identity,
	[name] varchar(20) not null,
);
go
insert into badge80Plus ([name])
values ('none'), ('white'), ('bronze'), ('silver'), ('gold'), ('platinum'), ('titanium');
go
create table powerSupply (
	id int primary key identity not null,
    [name] varchar(96) not null,
    imageUrl varchar(512) not null,
    potency int not null,
    badge80PlusId int foreign key references badge80Plus (id) not null,
    brandId int foreign key references brand(id) not null,
    -- constraint primary key(id)
);

create table machine (
	id int primary key identity not null,
    [name] varchar(96) not null,
    [description] varchar(512) not null,
    imageUrl varchar(512) not null,
    ramMemoryAmount int not null,
    graphicCardAmount int not null,
    motherboardId int foreign key references motherboard(id) not null,
    processorId int foreign key references processor(id) not null,
    ramMemoryId int foreign key references ramMemory(id) not null,
    graphicCardId int foreign key references graphicCard(id) not null,
    powerSupplyId int foreign key references powerSupply(id) not null,
    -- constraint primary key(id)
);

create table machineHasStorageDevice (
	id int primary key identity,
    amount int not null,
    machineId int foreign key references machine(id) on delete no action,
    storageDeviceId int foreign key references storageDevice(id) on delete no action,
);
