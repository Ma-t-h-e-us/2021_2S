--DML
insert into empresa (nomeEmpresa)
values ('EmpresaX')
go

insert into clientes (nomeClientes, sobrenomeClientes, cpfClientes)
values ('Lucas', 'Aragao', 555), ('Matheus', 'Martins', 777)
go

insert into marca (nomeMarca)
values('Ford'),('GM'),('Carrinhos')
go

insert into modelo (idMarca, nomeModelo)
values (1, 'modeloFord'),(2, 'modeloGM'),(3, 'modeloCarrinhos')
go

insert into veiculo (idEmpresa, idModelo, placa)
values (1, 1, 'aaa'),(1, 2, 'bbb')
go

insert into ALUGUEIS (idVeiculo, idClientes, inicioAluguel, fimAluguel)
values (1, 1, '1985-01-01 03:00:00', '2000-01-01 00:00:00'),(2, 2, '1988-01-01 00:00:00', '2010-01-01 00:00:00')
go