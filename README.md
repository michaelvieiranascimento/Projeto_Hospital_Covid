# Projeto_Hospital_Covid
Projeto para o hospital, foi feito um inicio, com 
1)Buscar paciente, que pede o cpf do paciente, se tiver, so imprimi os dados do paciente, se nao tiver, faz o cadastro do paciente e
ja inseri na fila normal ou na fila preferencial, dependendo da data de nascimento do paciente. Se >60 = Fila Preferencial e se <60 = Fila normal. 

2)Buscar paciente para exame, chama o paciente sendo 2 da fila preferencial e 1 da fila normal. //Busca do arquivo paciente.txt

3)Buscar Paciente, esse busca os dados do paciente.

4)Busca o Historico do paciente,
mostrando se esteve com algum sintoma e mostra data de nascimento, cpf e nome. 

5)Imprimir Fila normal, este so imprimi os pacientes que estao na fila normal 

6)Imprimir Fila preferencial,
este so imprimi os pacientes que estao na fila preferencial.

O que nao deu certo de fazer foi fazer a fila para os pacientes que estao em estado de emergencia que precisam ser internados nos leitos, nao deu para fazer a opcao de internar 
estes pacientes, o programa so inseri na fila, mas depois que o paciente é chamado para o exame, nao consegui fazer o metodo para retirar este paciente das filas.

Praticamente consegui fazer o programa que pede o cpf do paciente, se tiver no sistema, ele imprimi o paciente, se nao tiver, ele faz o cadastro do nome,cpf,data de nascimento e sexo,
e com esse cadastro, dependendo da sua idade, ja inseri em uma das filas dependendo da idade do paciente. Fiz uma busca do paciente se tiver, imprimi os dados do paciente, se nao tiver, 
ira imprimir que nao existe este contato, fiz uma opção para ver quem estao nas filas, se nao tiver, ele ira dizer que as filas estao vazias. E fiz que todos estes dados serem gravados em 
uma pasta com a data de quando esta sendo usado o programa, com um txt de dados do paciente, um txt da fila normal e um txt da fila preferencial.
