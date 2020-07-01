  SELECT wr.Id, wr.Name, wr.NeighborhoodId, ws.Id as WalkId, ws.Duration
                    FROM Walker wr
                    JOIN Walks ws ON wr.Id = ws.WalkerId
                    WHERE wr.Id = 4