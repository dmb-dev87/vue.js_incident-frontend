import axios from 'axios';
import repository from '../../../repositories/employeeRepository';

export default {
    setAttachmentDetials : ({commit },detail) => commit('setReference',detail),
    async fetchEmployees({ commit })
    {
        //const response = service.addTask(task);
        const response = await axios.get('http://localhost:8080/api/Employer');
        commit('setEmployees',response.data)
    },
    async addEmployee({commit},emp)
    {
        const response = await axios.put('http://localhost:8080/api/Employer',emp);
        commit('newEmployee',response.data)
    },
    async login({ commit },user)
    {
        repository.login(user).then(response=>{
        commit('setLogginStatus',response.loggedin);   
        commit('setResponse',response.status);
        });
        
    }

}