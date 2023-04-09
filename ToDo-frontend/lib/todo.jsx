export default async function getToDosByUser(id) {
    const link = "https://localhost:7198/api/v1/ToDo/" + id;

    const data = await fetch(link, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json'
        }
      });

      return data.json();

}

export async function addToDo(obj,id) {
  const date = new Date(Date.now() + obj.time * 24 * 60 * 60 * 1000);
  const data = await fetch("https://localhost:7198/api/v1/ToDo", {
    method: 'POST',
    body: JSON.stringify({
      title:obj.title,
      description:obj.desc,
      priority:obj.proirity,
      due:date.toISOString(),
      startTime:new Date(Date.now()).toISOString(),
      userId: id
    }),
    headers: {
      'Content-Type': 'application/json'
    }
  });

  return data.json();

}

export async function deleteToDo(id) {
  const link = "https://localhost:7198/api/v1/ToDo?id=" + id;

  const data = await fetch(link, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      }
    });

    return data.json();

}