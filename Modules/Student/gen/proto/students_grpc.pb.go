// Code generated by protoc-gen-go-grpc. DO NOT EDIT.
// versions:
// - protoc-gen-go-grpc v1.2.0
// - protoc             v3.21.8
// source: proto/students.proto

package __

import (
	context "context"
	grpc "google.golang.org/grpc"
	codes "google.golang.org/grpc/codes"
	status "google.golang.org/grpc/status"
)

// This is a compile-time assertion to ensure that this generated file
// is compatible with the grpc package it is being compiled against.
// Requires gRPC-Go v1.32.0 or later.
const _ = grpc.SupportPackageIsVersion7

// StudentsClient is the client API for Students service.
//
// For semantics around ctx use and closing/ending streaming RPCs, please refer to https://pkg.go.dev/google.golang.org/grpc/?tab=doc#ClientConn.NewStream.
type StudentsClient interface {
	CreateStudent(ctx context.Context, in *CreateStudentRequest, opts ...grpc.CallOption) (*Student, error)
	GetAllStudents(ctx context.Context, in *Empty, opts ...grpc.CallOption) (*GetAllStudentsResponse, error)
	GetStudentById(ctx context.Context, in *StudentID, opts ...grpc.CallOption) (*Student, error)
	DeleteStudent(ctx context.Context, in *StudentID, opts ...grpc.CallOption) (*MessageResponse, error)
}

type studentsClient struct {
	cc grpc.ClientConnInterface
}

func NewStudentsClient(cc grpc.ClientConnInterface) StudentsClient {
	return &studentsClient{cc}
}

func (c *studentsClient) CreateStudent(ctx context.Context, in *CreateStudentRequest, opts ...grpc.CallOption) (*Student, error) {
	out := new(Student)
	err := c.cc.Invoke(ctx, "/main.Students/CreateStudent", in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *studentsClient) GetAllStudents(ctx context.Context, in *Empty, opts ...grpc.CallOption) (*GetAllStudentsResponse, error) {
	out := new(GetAllStudentsResponse)
	err := c.cc.Invoke(ctx, "/main.Students/GetAllStudents", in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *studentsClient) GetStudentById(ctx context.Context, in *StudentID, opts ...grpc.CallOption) (*Student, error) {
	out := new(Student)
	err := c.cc.Invoke(ctx, "/main.Students/GetStudentById", in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

func (c *studentsClient) DeleteStudent(ctx context.Context, in *StudentID, opts ...grpc.CallOption) (*MessageResponse, error) {
	out := new(MessageResponse)
	err := c.cc.Invoke(ctx, "/main.Students/DeleteStudent", in, out, opts...)
	if err != nil {
		return nil, err
	}
	return out, nil
}

// StudentsServer is the server API for Students service.
// All implementations must embed UnimplementedStudentsServer
// for forward compatibility
type StudentsServer interface {
	CreateStudent(context.Context, *CreateStudentRequest) (*Student, error)
	GetAllStudents(context.Context, *Empty) (*GetAllStudentsResponse, error)
	GetStudentById(context.Context, *StudentID) (*Student, error)
	DeleteStudent(context.Context, *StudentID) (*MessageResponse, error)
	mustEmbedUnimplementedStudentsServer()
}

// UnimplementedStudentsServer must be embedded to have forward compatible implementations.
type UnimplementedStudentsServer struct {
}

func (UnimplementedStudentsServer) CreateStudent(context.Context, *CreateStudentRequest) (*Student, error) {
	return nil, status.Errorf(codes.Unimplemented, "method CreateStudent not implemented")
}
func (UnimplementedStudentsServer) GetAllStudents(context.Context, *Empty) (*GetAllStudentsResponse, error) {
	return nil, status.Errorf(codes.Unimplemented, "method GetAllStudents not implemented")
}
func (UnimplementedStudentsServer) GetStudentById(context.Context, *StudentID) (*Student, error) {
	return nil, status.Errorf(codes.Unimplemented, "method GetStudentById not implemented")
}
func (UnimplementedStudentsServer) DeleteStudent(context.Context, *StudentID) (*MessageResponse, error) {
	return nil, status.Errorf(codes.Unimplemented, "method DeleteStudent not implemented")
}
func (UnimplementedStudentsServer) mustEmbedUnimplementedStudentsServer() {}

// UnsafeStudentsServer may be embedded to opt out of forward compatibility for this service.
// Use of this interface is not recommended, as added methods to StudentsServer will
// result in compilation errors.
type UnsafeStudentsServer interface {
	mustEmbedUnimplementedStudentsServer()
}

func RegisterStudentsServer(s grpc.ServiceRegistrar, srv StudentsServer) {
	s.RegisterService(&Students_ServiceDesc, srv)
}

func _Students_CreateStudent_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(CreateStudentRequest)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(StudentsServer).CreateStudent(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: "/main.Students/CreateStudent",
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(StudentsServer).CreateStudent(ctx, req.(*CreateStudentRequest))
	}
	return interceptor(ctx, in, info, handler)
}

func _Students_GetAllStudents_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(Empty)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(StudentsServer).GetAllStudents(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: "/main.Students/GetAllStudents",
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(StudentsServer).GetAllStudents(ctx, req.(*Empty))
	}
	return interceptor(ctx, in, info, handler)
}

func _Students_GetStudentById_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(StudentID)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(StudentsServer).GetStudentById(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: "/main.Students/GetStudentById",
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(StudentsServer).GetStudentById(ctx, req.(*StudentID))
	}
	return interceptor(ctx, in, info, handler)
}

func _Students_DeleteStudent_Handler(srv interface{}, ctx context.Context, dec func(interface{}) error, interceptor grpc.UnaryServerInterceptor) (interface{}, error) {
	in := new(StudentID)
	if err := dec(in); err != nil {
		return nil, err
	}
	if interceptor == nil {
		return srv.(StudentsServer).DeleteStudent(ctx, in)
	}
	info := &grpc.UnaryServerInfo{
		Server:     srv,
		FullMethod: "/main.Students/DeleteStudent",
	}
	handler := func(ctx context.Context, req interface{}) (interface{}, error) {
		return srv.(StudentsServer).DeleteStudent(ctx, req.(*StudentID))
	}
	return interceptor(ctx, in, info, handler)
}

// Students_ServiceDesc is the grpc.ServiceDesc for Students service.
// It's only intended for direct use with grpc.RegisterService,
// and not to be introspected or modified (even as a copy)
var Students_ServiceDesc = grpc.ServiceDesc{
	ServiceName: "main.Students",
	HandlerType: (*StudentsServer)(nil),
	Methods: []grpc.MethodDesc{
		{
			MethodName: "CreateStudent",
			Handler:    _Students_CreateStudent_Handler,
		},
		{
			MethodName: "GetAllStudents",
			Handler:    _Students_GetAllStudents_Handler,
		},
		{
			MethodName: "GetStudentById",
			Handler:    _Students_GetStudentById_Handler,
		},
		{
			MethodName: "DeleteStudent",
			Handler:    _Students_DeleteStudent_Handler,
		},
	},
	Streams:  []grpc.StreamDesc{},
	Metadata: "proto/students.proto",
}
