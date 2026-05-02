-- 코드를 입력하세요
SELECT used_goods_board.title, used_goods_board.board_id, used_goods_reply.reply_id, used_goods_reply.writer_id, used_goods_reply.contents, DATE_FORMAT(used_goods_reply.created_date, '%Y-%m-%d') as create_date
FROM used_goods_board JOIN used_goods_reply
WHERE used_goods_board.board_id = used_goods_reply.board_id AND YEAR(used_goods_board.created_date) = '2022' AND MONTH(used_goods_board.created_date) = '10'
ORDER BY used_goods_reply.created_date ASC, used_goods_board.title ASC;