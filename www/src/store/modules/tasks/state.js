
export default {
  addTaskDialog: false,
  editTaskDialog: false,
  assignTaskDialog: false,

  selectedTask: {
    id: "",
    weight: 5,
    description: "",
    title: "",
    importance: 1,
    urgent: 2,
    section: 0,
    employees: [
      ""
    ],
    comments: [
      {
        id: null,
        commentString: "",
        commentedBy: "",
        commentedIn: ""
      }
    ],
    createdby: null,
    createdon: "",
    status: "",
    date: "",
    dueDate: "",
    actions: ""
  },


  tasks: []

  , headers: [
    { text: 'العنوان', value: 'title' },
    { text: 'الأولوية', value: 'urgent' },
    { text: 'توكيل المهمة الى', value: 'assigned_for' },
    { text: 'الحالة', value: 'status' },
    { text: 'الإجراء', value: 'actions' },
    
  ],
  weights: [
    { code: '1', label: '1' },
    { code: '2', label: '2' },
    { code: '3', label: '3' },
    { code: '4', label: '4' },
    { code: '5', label: '5' },
    { code: '6', label: '6' }],

  importance: [
    { code: "1", label: 'مهم' },
    { code: "2", label: 'غير مهم' },
  ],
  urgancy: [
    { code: "1", label: "عادي" },
    { code: "2", label: "عاجل" },
    { code: "3", label: "عاجل جدا" }],

  tasked_for: [
    { code: "1", label: 'سلطان' },
    { code: "3", label: 'سالم' },
    { code: "2", label: 'أحمد' }],

    
    

}
