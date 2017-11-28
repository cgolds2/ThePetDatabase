<?php

class User {

    // database connection and table name
    private $conn; private $table_name = "users";
    // object properties
    public $id;
    public $username;
    public $password_hash;
    public $shelter_id;
    public $email;

    // constructor with $db as database connection
    public function __construct($db) {
        $this->conn = $db;
    }


    function read_all() {
        // query to select all
        $query = "SELECT *
            FROM
                " . $this->table_name . " d
            ORDER BY
                d.id";
        // prepare query statement
        $stmt = $this->conn->prepare($query);

        // execute query
        $stmt->execute();

        return $stmt;
    }


    function read_id() {
        // query to select all
        $query = "SELECT *
            FROM
                " . $this->table_name . " d
            WHERE
                d.shelter_id = :shelter_id";
        // prepare query statement
        $stmt = $this->conn->prepare($query);

        // bind parameter
        $stmt->bindParam(":shelter_id", $this->shelter_id);

        // execute query
        $stmt->execute();

        return $stmt;
    }


    
    function get_user() {
        // query to select all
        $query = "SELECT *
            FROM
                " . $this->table_name . " d
            WHERE
                d.username = :username";
        // prepare query statement
        $stmt = $this->conn->prepare($query);

        // bind parameter
        $stmt->bindParam(":username", $this->username);

        // execute query
        $stmt->execute();

        return $stmt;
    }


    function create() {
        // query to insert record
        $query = "INSERT INTO
                " . $this->table_name . "
            SET
                username=:username,
                password_hash=:password_hash,
                shelter_id=:shelter_id,
                email=:email";

        // prepare query
        $stmt = $this->conn->prepare($query);

        // bind parameters
        $stmt->bindParam(":username", $this->username);
        $stmt->bindParam(":password_hash", $this->password_hash);
        $stmt->bindParam(":shelter_id", $this->shelter_id);
        $stmt->bindParam(":email", $this->email);

        // execute query
        if ($stmt->execute()) {
            return $this->conn->lastInsertId();
        } else {
            return false;
        }
    }


    function update() {
        // query to update record
        $query = "UPDATE
                " . $this->table_name . "
            SET
                email=:email
            WHERE
                username=:username";

        // if new password provided, update password_hash
        if ($this->password_hash != null) {
            $query = "UPDATE
                    " . $this->table_name . "
                SET
                    password_hash=:password_hash,
                    email=:email
                WHERE
                    username=:username";
        }
        // prepare query
        $stmt = $this->conn->prepare($query);

        // bind parameters
        $stmt->bindParam(":username", $this->username);
        $stmt->bindParam(":email", $this->email);
        if ($this->password_hash != null) {
            $stmt->bindParam(":password_hash", $this->password_hash);
        }

        // execute query
        if ($stmt->execute()) {
            return true;
        } else {
            return false;
        }
    }


    function delete() {
        // query to delete all
        $query = "DELETE FROM " . $this->table_name . " WHERE id = ?";

        // prepare query statement
        $stmt = $this->conn->prepare($query);

        // bind parameter
        $stmt->bindParam(1, $this->id);

        // execute query
        if ($stmt->execute()) {
            return true;
        } else {
            return false;
        }
    }

}
