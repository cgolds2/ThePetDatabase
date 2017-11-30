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


    function read_id() {
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
