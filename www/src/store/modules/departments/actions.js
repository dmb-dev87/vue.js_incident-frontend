import axios from 'axios';

export default {

    changeSector: ({ commit }, Sector) => commit("setSector",Sector),

    SaveSectors: ({ commit }, departments) => commit("SameSectors",departments),

    AddOrg: ({ commit }, payload ) => commit("saveOrg", payload ),

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