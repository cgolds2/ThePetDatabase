<?php

header("Access-Control-Allow-Origin: *");

class Db {

    private $host = "localhost";
    private $db_name = "REPLACE WITH ACTUAL DATABASE NAME";
    private $username = "REPLACE WITH ACTUAL USERNAME";
    private $password = "REPLACE WITH ACTUAL PASSWORD";
    public $conn;

    // get the database connection
    public function getConnection() {
        $this->conn = null;

        try {
            $this->conn = new PDO("mysql:host=" . $this->host . ";dbname=" . $this->db_name, $this->username, $this->password);
            $this->conn->exec("set names utf8");
        } catch (PDOException $exception) {
            echo "Database connection error: " . $exception->getMessage();
        }

        return $this->conn;
    }

}

?>

