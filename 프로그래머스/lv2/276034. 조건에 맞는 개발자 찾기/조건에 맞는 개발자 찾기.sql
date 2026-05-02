SELECT DISTINCT id, email, first_name, last_name FROM DEVELOPERS d
LEFT JOIN SKILLCODES s ON s.name = 'Python' or s.name = 'C#'
WHERE d.skill_code & s.code
ORDER BY id;