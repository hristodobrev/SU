<?php

class UsersModel extends BaseModel
{
    public function login(string $username, string $password)
    {
        $statement = self::$db->prepare(
            "SELECT * FROM users WHERE username = ?"
        );

        $statement->bind_param("s", $username);
        $statement->execute();

        $result = $statement->get_result()->fetch_assoc();

        if (!password_verify($password, $result['password'])) {
            return false;
        }

        return $result['id'];
    }

    public function register(string $username, string $password, string $fullName)
    {
        $passwordHash = password_hash($password, PASSWORD_DEFAULT);

        if($fullName) {
            $statement = self::$db->prepare(
                "INSERT INTO users(username, password, full_name) VALUES(?, ?, ?)"
            );
            $statement->bind_param("sss", $username, $passwordHash, $fullName);
        } else {
            $statement = self::$db->prepare(
                "INSERT INTO users(username, password) VALUES(?, ?)"
            );
            $statement->bind_param("ss", $username, $passwordHash);
        }
        $statement->execute();

        if ($statement->affected_rows != 1) {
            if ($statement->errno == 1062) {
                throw new Error('A user with the same name already exists.');
            }

            return false;
        }

        $userId = self::$db->query("SELECT LAST_INSERT_ID()");
        return $userId;
    }
}

?>