DELIMITER $$

CREATE PROCEDURE `db_a428fb_mg`.`usp_getUserFavoriteParsedTextByMediaId` 
(IN inputMediaId varchar(255))
BEGIN
 select * from parsedtext pt inner join mediatext mt 
on pt.mediatextid = mt.id inner join userfavorite uf
 on pt.id = uf.ParsedTextId
where mt.mediaId= inputMediaId;
END 