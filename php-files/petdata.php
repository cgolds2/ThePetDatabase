<?php

class PetData {

    // database connection and table name
    private $conn; private $table_name = "pet_data";
    // object properties
    public $id;
    public $age;
    public $name;
    public $notes;
    public $breed;
    public $animal_type;
    public $weight;
    public $shelter_id;
    public $profile_picture;
    public $size;
    public $chip_id;

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


    function create() {
        // query to insert record
        $query = "INSERT INTO
                " . $this->table_name . "
            SET
                age=:age,
                name=:name,
                notes=:notes,
                breed=:breed,
                animal_type=:animal_type,
                weight=:weight,
                shelter_id=:shelter_id,
                profile_picture=:profile_picture,
                size=:size,
                chip_id=:chip_id";

        // prepare query
        $stmt = $this->conn->prepare($query);

        // bind parameters
        $stmt->bindParam(":age", $this->age);
        $stmt->bindParam(":name", $this->name);
        $stmt->bindParam(":notes", $this->notes);
        $stmt->bindParam(":breed", $this->breed);
        $stmt->bindParam(":animal_type", $this->animal_type);
        $stmt->bindParam(":weight", $this->weight);
        $stmt->bindParam(":shelter_id", $this->shelter_id);
        $stmt->bindParam(":profile_picture", $this->profile_picture);
        $stmt->bindParam(":size", $this->size);
        $stmt->bindParam(":chip_id", $this->chip_id);

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
                age=:age,
                name=:name,
                notes=:notes,
                breed=:breed,
                animal_type=:animal_type,
                weight=:weight,
                shelter_id=:shelter_id,
                size=:size,
                chip_id=:chip_id
            WHERE
                id=:id";
        // prepare query
        $stmt = $this->conn->prepare($query);

        // bind parameters
        $stmt->bindParam(":id", $this->id);
        $stmt->bindParam(":age", $this->age);
        $stmt->bindParam(":name", $this->name);
        $stmt->bindParam(":notes", $this->notes);
        $stmt->bindParam(":breed", $this->breed);
        $stmt->bindParam(":animal_type", $this->animal_type);
        $stmt->bindParam(":weight", $this->weight);
        $stmt->bindParam(":shelter_id", $this->shelter_id);
        $stmt->bindParam(":size", $this->size);
        $stmt->bindParam(":chip_id", $this->chip_id);

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


    function add_profile_pic() {
        // query to update record
        $query = "UPDATE
                " . $this->table_name . "
            SET
                profile_picture=:profile_picture
            WHERE
                id=:id";
        // prepare query
        $stmt = $this->conn->prepare($query);

        // bind parameters
        $stmt->bindParam(":id", $this->id);
        $stmt->bindParam(":profile_picture", $this->profile_picture);

        // execute query
        if ($stmt->execute()) {
            return true;
        } else {
            return false;
        }
    }



    function get_profile_pic() {
        // query to select all
        $query = "SELECT profile_picture
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

}
