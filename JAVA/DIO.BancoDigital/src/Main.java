
public class Main {

	public static void main(String[] args) {
		Cliente cliente = new Cliente();
		cliente.setNome("Novo Cliente");
		
		Conta cc = new ContaCorrente(cliente);
		Conta poupanca = new ContaPoupanca(cliente);

		cc.depositar(1000);
		cc.transferir(100, poupanca);
		
		cc.imprimirExtrato();
		poupanca.imprimirExtrato();
	}

}
