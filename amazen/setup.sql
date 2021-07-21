CREATE TABLE Products(
  id VARCHAR(255) NOT NULL primary key comment 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  name varchar(255) NOT NULL comment 'Users given name',
  price INT NOT NULL COMMENT 'Price of Item',
  picture varchar(255) NOT NULL comment 'Item Picture URL'
) default charset utf8 comment '';
CREATE TABLE IF NOT EXISTS contracts(
  id INT AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) NOT NULL COMMENT 'Job Name',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: User Account',
  description VARCHAR(255) COMMENT 'job Description',
  location VARCHAR(255) COMMENT 'job location',
  FOREIGN KEY (creatorId) REFERENCES Accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS contract_bids(
  id INT AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  bid_amount INT NOT NULL COMMENT 'Job NameBid Amountg',
  contractorId VARCHAR(255) NOT NULL COMMENT 'User Account',
  description VARCHAR(255) COMMENT 'Description of job assertions',
  contractId INT COMMENT 'FK: job bid Id',
  FOREIGN KEY (contractId) REFERENCES contracts(id) ON DELETE CASCADE,
  FOREIGN KEY (contractorId) REFERENCES Accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
INSERT INTO
  contracts(name, description, location, creatorId)
VALUES
  (
    "Tree Removal",
    "Two Willow trees each have 6ft plus removal of wood",
    "4012 Preakness Way Nampa",
    "60cb8ac8f08aa1ea8ecb824a"
  );
INSERT INTO
  contract_bids(bid_amount, description, contractorId, contractId)
VALUES
  (
    "999",
    "Will saw logs into max-length 2 ft logs for removal tempory storage at site requested",
    "60cb8ac8f08aa1ea8ecb824a",
    "1"
  );

select * from Accounts;





SELECT
  *
from
  contract_bids;