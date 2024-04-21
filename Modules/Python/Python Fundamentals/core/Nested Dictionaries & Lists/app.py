# =================== 1 ===================
print("=================== 1 ===================\n")

x = [ [5,2,3], [10,8,9] ] 
students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'}
]
sports_directory = {
    'basketball' : ['Kobe', 'Jordan', 'James', 'Curry'],
    'soccer' : ['Messi', 'Ronaldo', 'Rooney']
}
z = [ {'x': 10, 'y': 20} ]

# 1-1
x[1][0] = 15
print(x)
# 1-2
students[0]['last_name'] = 'Bryant'
print(students)
# 1-3
sports_directory['soccer'][0] = 'Andres'
print(sports_directory)
# 1-4
z[0]['y'] = 30
print(z)

# =================== 2 ===================
print("\n=================== 2 ===================\n")

students = [
         {'first_name':  'Michael', 'last_name' : 'Jordan'},
         {'first_name' : 'John', 'last_name' : 'Rosales'},
         {'first_name' : 'Mark', 'last_name' : 'Guillen'},
         {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ]
def iterateDictionary(students): 
# should output: (it's okay if each key-value pair ends up on 2 separate lines;
# bonus to get them to appear exactly as below!)
    msgs = ""
    for student in students:
        keys = list(student.keys())
        msg = ""
        for i in range(len(keys)):
            msg += (f"{keys[i]} - {student[keys[i]]}")
            if(i != len(keys)-1):
                msg += ", "
        msgs += msg + "\n"

    return msgs

print(iterateDictionary(students))

print("\n=================== 3 ===================\n")

def iterateDictionary2(key_name, some_list):
    for dict in some_list:
        for key in dict:
            if(key == key_name):
                print(dict[key])

iterateDictionary2('first_name', students)

print("\n=================== 4 ===================")

def printInfo(some_dict):
    for key in some_dict:
        print("\n")
        print(f"{len(some_dict[key])} LOCATIONS")
        for location in some_dict[key]:
            print(location)
        

dojo = {
   'locations': ['San Jose', 'Seattle', 'Dallas', 'Chicago', 'Tulsa', 'DC', 'Burbank'],
   'instructors': ['Michael', 'Amy', 'Eduardo', 'Josh', 'Graham', 'Patrick', 'Minh', 'Devon']
}
printInfo(dojo)