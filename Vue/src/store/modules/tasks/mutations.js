export default {
    setTasks :(state,tasks) =>state.tasks = tasks,
    newTask : (state,task) => state.tasks.push(task),
    setAddTaskDialog : (state,status) => state.addTaskDialog = status,
    setEditTaskDialog : (state,status) => state.editTaskDialog = status,
    setDefaultSelectedItem : (state) => state.selectedTask  = state.defaultTask,
    setAssignTaskDialog : (state,status) => state.assignTaskDialog = status,
    addComment :(state,comment) => state.selectedTask.comments.push(comment),
    setSelecteItem : (state,task) => state.selectedTask = task,
 }