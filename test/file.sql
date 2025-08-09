// Example of a complicated SQL script.
SELECT
    users.id,
    users.name,
    COUNT(orders.id) AS order_count
FROM
    users
LEFT JOIN
    orders ON users.id = orders.user_id
WHERE
    users.created_at >= '2023-01-01'
GROUP BY
    users.id
HAVING
    order_count > 5
ORDER BY
    users.name ASC;