import axios from 'axios';

export default {

    changeSector: ({ commit }, Sector) => commit("setSector",Sector),

    async SaveSectors ({ commit }, statusType) {
      commit("SameSectors",statusType);
      const response = await axios.post('http://localhost:8080/api/statusTypes',statusType);
     },

     async AddOrg ({ commit }, statusTypes ) {
      let st = {
        id : 1,
        statuses: [{StatusString: "salim alismaili"}]
      }
       console.log(statusTypes);
       const response = await axios.put('http://localhost:8080/api/statusTypes',st);
      commit("saveOrg", statusTypes);
    },
    removeOrganization : ({ commit }, index) => commit("removeOrganization",index),

    async save({commit},sector)
    {
        const response = await axios.post('http://localhost:8080/api/APTs',sector);
        commit('newTask',response.data)
    },

    async fetchOrganizations({ commit })
    {
        const response = await axios.get('http://localhost:8080/api/Country');
        commit('setOrganization',response.data)
    },


}
