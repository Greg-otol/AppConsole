using AppConsole.Infra.Alunos;
using AppConsole.Infra.Disciplinas;
using AppConsole.Infra.Notas;
using AppConsole.Servicos.Alunos;
using AppConsole.Servicos.Disciplinas;
using AppConsole.Servicos.Notas;
using AppConsole.Visualizacoes;
using AppConsole.Visualizacoes.Alunos;
using AppConsole.Visualizacoes.Disciplinas;
using AppConsole.Visualizacoes.Menus;
using AppConsole.Visualizacoes.Notas;

var alunoRepositorio = new AlunoRepositorio();
var alunoServico = new AlunoServico(alunoRepositorio);

var disciplinaRepositorio = new DisciplinaRepositorio();
var disciplinaServico = new DisciplinaServico(disciplinaRepositorio);

var notaRepositorio = new NotaRepositorio();
var notaServico = new NotaServico(notaRepositorio);

// Telas
var menus = new Menu(alunoServico, disciplinaServico);

var cadastroAluno = new CadastroAluno(alunoServico);
var listagemAluno = new ListagemAluno(alunoServico);

var cadastroNota = new CadastroNota(notaServico, menus, alunoServico, disciplinaServico);
var listagemNota = new ListagemNota(alunoServico, disciplinaServico, notaServico);

var cadastroDisciplina = new CadastroDisciplina(alunoServico, disciplinaServico, menus);

var telaPrincipal = new TelaPrincipal(alunoServico, disciplinaServico, listagemAluno, cadastroAluno, cadastroDisciplina, menus, cadastroNota, listagemNota);

telaPrincipal.Menu();
