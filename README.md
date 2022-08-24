# EscolaAPI - Objetivo

O objetivo base da API em questão é operar no setor administrativo de uma escola, auxiliando o cadastro, atualização, remoção de alunos e professores, turmas e disciplinas envolvidos naquela escola, facilitando dessa forma o setor administrativo.

## Autenticação

A criação do banco de dados através do EscolaContext já adiciona alguns dados no banco, inclusive dois usuários: admin e func, um é administrador e tem privilégios de administrador, outro é funcionário e tem acesso restrito. Toda essa configuração de segurança da API foi realizada utilizando tokens JwT, e para efetuar qualquer operação na API é necessário realizar a autenticação.  

## DTOS

Há DTOs com finalidades específicas dentro da aplicação, a saber:

• DTOs que se iniciam com "CriarModeloDTO", servem para auxiliar nos métodos Post()  
• DTOs com finalizações em "BasicoDTO/BasicaDTO" servem para auxiliar no retorno de métodos GetAll()  
• DTO que possui o nome do modelo e termina com DTO, por exemplo "TurmaDTO" serve para auxiliar em métodos GetById()



