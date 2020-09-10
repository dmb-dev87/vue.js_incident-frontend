import axios from 'axios';

export default {
  async fetchIncidents({ commit })
  {
    //const response = service.addTask(task);
    const response = await axios.get('https://localhost:44392/api/Incidents');
    commit('setIncidents',response.data)
  },
  async addIncident({commit},item)
  {
    commit('addIncidence', item);
    // const response = await axios.post('http://localhost:8080/api/Incidnts',Inci);
    // commit('newIncidnt',response.data)
  },
  deleteIncident({commit}, item){
    commit('deleteIncident',item);
  },
  editIncident({commit}, item){
    commit('editIncident',item);
  },
  addComment({ commit }, item) {
    commit("addComment", item);
  }
}
