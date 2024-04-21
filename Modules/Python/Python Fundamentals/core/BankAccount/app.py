class BankAccount:
    accounts = []

    def __init__(self, int_rate = 0.01, balance = 0): 
        self.int_rate = int_rate
        self.balance = balance
    
    def deposit(self, amount):
        self.balance += amount

    def withdraw(self, amount):
        if(self.balance >= amount):
            self.balance -= amount
        else:
            print("Insufficient funds: Charging a $5 fee")
            self.balance -= 5

    def display_account_info(self):
        print(f"Balance: ${self.balance}")

    def yield_interest(self):
        if(self.balance > 0):
            self.balance += self.balance * self.int_rate

    @classmethod
    def display_all_accounts(cls):
        for account in cls.accounts:
            account.display_account_info()

class User:
    def __init__(self, name, email):
        self.name = name
        self.email = email
        self.account = BankAccount(0.02)
    
    # other methods
    
    def make_deposit(self, amount):
        self.account.deposit(amount)

    def make_withdrawal(self, amount):
        self.account.withdraw(amount)

    def display_user_balance(self):
    	self.display_user_balance()

chawki = BankAccount()
daniel = BankAccount()

BankAccount.accounts.append(chawki)
BankAccount.accounts.append(daniel)

chawki.deposit(100)
chawki.deposit(100)
chawki.deposit(100)
chawki.withdraw(170)
chawki.yield_interest()
chawki.display_account_info()

daniel.deposit(20)
daniel.deposit(75)
daniel.withdraw(10)
daniel.withdraw(5)
daniel.withdraw(8)
daniel.withdraw(20)
daniel.display_account_info()

BankAccount.display_all_accounts()