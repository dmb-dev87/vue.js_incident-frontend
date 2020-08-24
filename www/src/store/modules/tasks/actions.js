import axios from 'axios';

export default {
    async fetchTasks({ commit })
    {
        const response = await axios.get('http://localhost:8080/api/Tasks');
        commit('setTasks',response.data)
    },
    async addTask({commit},task)
    {
        commit('newTask', task);
        //const response = await axios.post('http://localhost:8080/api/Tasks',task);
        //commit('newTask',response.data)
    },
    async updateTask({commit},task){
        const response = await axios.put('http://localhost:8080/api/Tasks',task);
        commit('setTasks',response.data)
    },
    async addCommentToTask ({commit},comment) { commit('addComment',comment) },
    setSelectedTask({commit},comment){
                
    }

}