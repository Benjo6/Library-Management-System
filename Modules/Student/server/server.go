package main

import (
	"context"
	"fmt"
	"log"
	"net"

	mapper "abed01/grpc/database"
	pb "abed01/grpc/gen/proto"

	"google.golang.org/grpc"
)

type studentServer struct {
	pb.UnimplementedStudentsServer
}

func (s *studentServer) CreateStudent(ctx context.Context, in *pb.CreateStudentRequest) (*pb.Student, error) {
	return mapper.CreateStudent(in.Firstname, in.Lastname, in.Balance), nil
}

func (s *studentServer) GetAllStudents(ctx context.Context, in *pb.Empty) (*pb.GetAllStudentsResponse, error) {
	return &pb.GetAllStudentsResponse{Students: mapper.GetAllStudents()}, nil
}

func (s *studentServer) GetStudentById(ctx context.Context, in *pb.StudentID) (*pb.Student, error) {
	return mapper.GetStudentById(int64(in.GetId())), nil
}
func (s *studentServer) DeleteStudent(ctx context.Context, in *pb.StudentID) (*pb.MessageResponse, error) {
	res := fmt.Sprintf("Student with id %s has been deleted succesfully!", mapper.DeleteStudent(int64(in.GetId())))
	return &pb.MessageResponse{Msg: res}, nil
}

func main() {
	listen, err := net.Listen("tcp", "localhost:8080")
	if err != nil {
		log.Fatalln(err)
	}
	grpcServer := grpc.NewServer()
	pb.RegisterStudentsServer(grpcServer, &studentServer{})

	err = grpcServer.Serve(listen)
	if err != nil {
		log.Fatalln(err)
	}
}
