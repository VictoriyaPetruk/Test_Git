﻿CREATE TABLE ORDERS(ID_O INTEGER PRIMARY KEY IDENTITY,ID_C INTEGER not null,DATE_O DATETIME,ADRESS CHAR(150),CONSTRAINT FK_Orders_To_Customers FOREIGN KEY (ID_C) REFERENCES CUSTOMER (ID_C) ON DELETE CASCADE);