UPDATE dwnumber t1
INNER JOIN (
	SELECT
		@x := ifnull(@x, 0) + 1 AS rownum,
		p
	FROM
		(SELECT @x := 0) r,
		dwnumber
	ORDER BY
		p ASC
) t2 ON t1.p = t2.p
SET t1.seq = t2.rownum;