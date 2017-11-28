<?php

class Picture {

    // database connection and table name
    private $conn; private $table_name = "pictures";
    // object properties
    public $id;
    public $pet_id;
    public $data;

    // constructor with $db as database connection
    public function __construct($db) {
        $this->conn = $db;
    }


    function read_all() {
        // query to select all
        $query = "SELECT *
            FROM
                " . $this->table_name . " d
            WHERE
                d.pet_id = :pet_id";
        // prepare query statement
        $stmt = $this->conn->prepare($query);

        // bind parameter
        $stmt->bindParam(":pet_id", $this->pet_id);

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
                d.id = :id";
        // prepare query statement
        $stmt = $this->conn->prepare($query);

        // bind parameter
        $stmt->bindParam(":id", $this->id);

        // execute query
        $stmt->execute();

        return $stmt;
    }


    function is_admin() {
        // query to select all
        $query = "SELECT *
            FROM
                " . $this->table_name . " d
            WHERE
                d.id = :id AND d.admin_id = :uid";
        // prepare query statement
        $stmt = $this->conn->prepare($query);

        // bind parameter
        $stmt->bindParam(":id", $this->id);
        $stmt->bindParam(":uid", $this->admin_id);

        // execute query
        $stmt->execute();

        return $stmt;
    }

    function create() {
        // query to insert record
        $query = "INSERT INTO
                " . $this->table_name . "
            SET
                pet_id=:pet_id,
                data=:data";

        // prepare query
        $stmt = $this->conn->prepare($query);

        // bind parameters
        $stmt->bindParam(":pet_id", $this->pet_id);
        $stmt->bindParam(":data", $this->data);

        // execute query
        if ($stmt->execute()) {
            return true;
        } else {
            return false;
        }
    }


    function update() {
        // query to update record
        $query = "UPDATE
                " . $this->table_name . "
            SET
                name=:name,
                website=:website,
                address=:address,
                phone_number=:phone_number,
                admin_id=:admin_id
            WHERE
                id=:id";
        // prepare query
        $stmt = $this->conn->prepare($query);

        // bind parameters
        $stmt->bindParam(":id", $this->id);
        $stmt->bindParam(":name", $this->name);
        $stmt->bindParam(":address", $this->address);
        $stmt->bindParam(":website", $this->website);
        $stmt->bindParam(":phone_number", $this->phone_number);
        $stmt->bindParam(":admin_id", $this->admin_id);

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
