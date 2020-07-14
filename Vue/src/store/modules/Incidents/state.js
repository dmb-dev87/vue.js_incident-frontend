export default {
  Incidents:
     [
      {
        id: 1,
        Subject: "فيروس الفدية ",
        Sver: { code: "1", label: "المستوى الخامس" },
        Org: { code: "1", label: "وزارة الاعلام" },
        Status: { code: "1", label: "مفتوحة" },
        Cat: { code: "1", label: "حصان طروادة" },
        Description: "هنا الوصف التحليلي ",
        Sector: { code: "2", label: "المؤسسات الحيوية" },
        Urgancey: { code: "1", label: "عادي" },
        ipAddresses: [
          {
            id: "12516126",
            ip: "85.65.145.5"
          }
        ]
      },
    ],
  Headers: [
    { text: 'العنوان', value: 'Subject' },
    { text: 'مستوى الخطورة', value: 'Sver' },
    { text: 'الجهة المتأثرة', value: 'Org' },
    { text: 'الإجراء', value: 'actions' },
  ],
  Cat: [
    { code: "1", label: "حصان طروادة" },
    { code: "2", label: "تعطيل الخدمة" },
    { code: "3", label: "حقن قواعد البيانات" }
  ],
  Sector: [
    { code: "1", label: "الوزارات الخدمية" },
    { code: "2", label: "المؤسسات الحيوية" },
    { code: "3", label: " القطاع الخاص" },
    { code: "4", label: "  القطاع العسكري" }
  ],
  Org: [
    { code: "1", label: "وزارة الاعلام" },
    { code: "4", label: "وزارة التجارة و الصناعة" },
    { code: "2", label: "وزارة البيئة" },
    { code: "3", label: "وزارة التربية و التعليم" }
  ],
  Urgancey: [
    { code: "1", label: "عادي" },
    { code: "2", label: "عاجل" },
    { code: "3", label: "عاجل جدا" }
  ],
  Sver: [
    { code: "1", label: "المستوى الخامس" },
    { code: "2", label: "المستوى الرايع" },
    { code: "3", label: "المستوى الثالث" },
    { code: "4", label: "المستوى الثاني" },
    { code: "5", label: "المستوى الاول" }
  ],
  Status: [
    { code: "1", label: "مفتوحة" },
    { code: "2", label: "مغلقة" },
    { code: "3", label: "قيد الاجراء" },
  ],
  comments: []
}


