package database

import (
	"context"
	"database/sql"
	"fmt"
	"log"

	pb "abed01/grpc/gen/proto"

	_ "github.com/go-sql-driver/mysql"
)

func checkError(err error) {
	if err != nil {
		log.Fatalln(err)
	}
}

func getdb() *sql.DB {
	db, err := sql.Open("mysql", "root:abed123@tcp(127.0.0.1:3307)/mydb")
	checkError(err)
	return db
}

func CreateStudent(firstname string, lastname string, balance float32) *pb.Student {
	db := getdb()
	defer db.Close()
	query := ("insert into Students (firstname, lastname, balance) values (?, ?, ?)")
	stmt, err := db.PrepareContext(context.Background(), query)
	checkError(err)
	res, err := stmt.ExecContext(context.Background(), firstname, lastname, balance)
	checkError(err)
	id, err := res.LastInsertId()
	checkError(err)
	student := GetStudentById(id)
	return student

}

func GetStudentById(id int64) *pb.Student {
	var student pb.Student
	db := getdb()
	defer db.Close()
	query := ("SELECT * FROM Students WHERE id = ?")
	row := db.QueryRow(query, id)
	switch err := row.Scan(&student.Id, &student.Firstname, &student.Lastname, &student.Balance); err {
	case sql.ErrNoRows:
		fmt.Println("No Student found by given id")
	case nil:

	default:
		log.Fatalln(err)
	}
	return &student

}

func GetAllStudents() []*pb.Student {
	db := getdb()
	defer db.Close()
	res, err := db.Query("SELECT * FROM Students")
	checkError(err)
	var students []*pb.Student
	for res.Next() {
		var student pb.Student
		err := res.Scan(&student.Id, &student.Firstname, &student.Lastname, &student.Balance)
		checkError(err)
		students = append(students, &student)
	}
	return students
}

func DeleteStudent(id int64) string {
	db := getdb()
	defer db.Close()
	query := "DELETE FROM Students WHERE id = ?"
	stmt, err := db.PrepareContext(context.Background(), query)
	checkError(err)
	_, nerr := stmt.ExecContext(context.Background(), id)
	checkError(nerr)
	return "Student have been succesfully deleted"
}
